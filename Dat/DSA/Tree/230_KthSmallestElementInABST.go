package tree

func kthSmallest(root *TreeNode, k int) int {
	res := 0
	inOrder(root, &k, &res)
	return res
}

func inOrder(node *TreeNode, k *int, res *int) {
	if node == nil {
		return
	}

	inOrder(node.Left, k, res)

	*k--
	if *k == 0 {
		*res = node.Val
		return
	}

	inOrder(node.Right, k, res)
}
