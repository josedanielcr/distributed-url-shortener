#!/usr/bin/env bash
set -euo pipefail

# This script bootstraps the Kubernetes control plane on node1
# Run it as root:  sudo bash init-control-plane.sh

POD_CIDR="10.244.0.0/16"   # Default for Flannel; adjust if you pick another CNI

echo "==> [1] Initializing Kubernetes control plane with kubeadm"
kubeadm init --pod-network-cidr=${POD_CIDR} | tee /root/kubeadm-init.log

echo "==> [2] Setting up kubectl for current user"
mkdir -p $HOME/.kube
cp -i /etc/kubernetes/admin.conf $HOME/.kube/config
chown $(id -u):$(id -g) $HOME/.kube/config

echo "==> [3] Showing cluster status"
kubectl get nodes || true

echo ""
echo "==> Control plane initialized!"
echo "Next steps:"
echo " 1) Install a CNI plugin (Flannel or Calico). For example:"
echo "      kubectl apply -f https://raw.githubusercontent.com/flannel-io/flannel/master/Documentation/kube-flannel.yml"
echo " 2) Copy the kubeadm join command printed above (also saved in /root/kubeadm-init.log)"
echo "    and run it on each worker node (node2, node3)."