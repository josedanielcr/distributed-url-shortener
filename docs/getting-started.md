# This guide shows how to create a simple 3-node Kubernetes cluster using Multipass and kubeadm.

* node1 → Control Plane (brains)
* node2 → Worker
* node3 → Worker

---

## Create VMs with Multipass
``` shell
multipass launch --name node1 --cpus 2 --memory 2G --disk 20G
multipass launch --name node2
multipass launch --name node3
```
Check they’re running and note their IPs:
`multipass list` and access them with `multipass shell (node1/node2/node3)`

## Prepare Each Node
transfer the `setup-k8s-node.sh` script to all nodes using
``` shell
multipass transfer setup-k8s-node.sh (name of the node):/home/ubuntu/
```
run it on each node using `sudo bash setup-k8s-node.sh`

## Initialize the Control Plane (node1 only)
On node1:
``` shell 
sudo bash init-control-plane.sh
```

## Install a CNI Plugin (node1 only)
run:
``` shell
kubectl apply -f https://raw.githubusercontent.com/flannel-io/flannel/master/Documentation/kube-flannel.yml
```

and after around a minute run `kubectl get nodes` it should show node1 as Ready

## Join Worker Nodes
on node1 run:
``` shell
kubeadm token create --print-join-command
```

copy the result and execute on node2 and node3.

## Result
You now have a working 3-node Kubernetes cluster with one control-plane and two workers.