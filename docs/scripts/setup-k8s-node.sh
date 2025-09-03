#!/usr/bin/env bash
set -euo pipefail

echo "==> [0] Checking privileges"
if [ "$EUID" -ne 0 ]; then
  echo "Please run as root (use: sudo bash setup-k8s-node.sh)"; exit 1
fi

echo "==> [1] Basic OS prep: disable swap & set sysctls"
# Disable swap now and across reboots
swapoff -a || true
if grep -q ' swap ' /etc/fstab; then
  cp /etc/fstab /etc/fstab.bak.$(date +%s)
  sed -i '/ swap / s/^\(.*\)$/# \1/' /etc/fstab
fi

# Kernel modules and sysctls needed for Kubernetes networking
modprobe overlay || true
modprobe br_netfilter || true
cat >/etc/modules-load.d/k8s.conf <<'EOF'
overlay
br_netfilter
EOF

cat >/etc/sysctl.d/k8s.conf <<'EOF'
net.bridge.bridge-nf-call-iptables=1
net.bridge.bridge-nf-call-ip6tables=1
net.ipv4.ip_forward=1
EOF
sysctl --system

echo "==> [2] Install container runtime: containerd"
apt-get update -y
apt-get install -y containerd

mkdir -p /etc/containerd
if [ ! -f /etc/containerd/config.toml ]; then
  containerd config default >/etc/containerd/config.toml
fi

# Ensure systemd cgroups for kubelet compatibility
if grep -q 'SystemdCgroup = false' /etc/containerd/config.toml; then
  sed -i 's/SystemdCgroup = false/SystemdCgroup = true/' /etc/containerd/config.toml
fi

systemctl enable --now containerd
systemctl restart containerd

echo "==> [3] Install kubeadm, kubelet, kubectl (Kubernetes apt repo v1.30)"
apt-get install -y apt-transport-https ca-certificates curl gpg

mkdir -p /etc/apt/keyrings
curl -fsSL https://pkgs.k8s.io/core:/stable:/v1.30/deb/Release.key \
 | gpg --dearmor -o /etc/apt/keyrings/kubernetes-apt-keyring.gpg

cat >/etc/apt/sources.list.d/kubernetes.list <<'EOF'
deb [signed-by=/etc/apt/keyrings/kubernetes-apt-keyring.gpg] https://pkgs.k8s.io/core:/stable:/v1.30/deb/ /
EOF

apt-get update -y
apt-get install -y kubelet kubeadm kubectl
apt-mark hold kubelet kubeadm kubectl

echo "==> [4] Versions"
echo -n "containerd: "; containerd --version || true
echo -n "kubeadm: "; kubeadm version -o short || true
echo -n "kubelet: "; kubelet --version || true
echo -n "kubectl: "; kubectl version --client --short || true

echo "==> Done. Next steps on the CONTROL PLANE node:"
echo "    kubeadm init --pod-network-cidr=10.244.0.0/16"
echo "    # then set up kubectl for your user and install a CNI (Flannel/Calico)."
echo "==> On WORKER nodes:"
echo "    Use the 'kubeadm join ...' command printed by the control plane."