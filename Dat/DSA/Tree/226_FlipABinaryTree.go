package tree

func invertTree(root *TreeNode) *TreeNode {
	if root == nil {
		return nil
	}

	tmp := root.Left
	root.Left = invertTree(root.Right)
	root.Right = invertTree(tmp)
	return root
}
