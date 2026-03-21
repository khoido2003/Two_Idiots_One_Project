package tree

func isSymmetric(root *TreeNode) bool {
	return root == nil || try(root.Left, root.Right)
}

func try(l, r *TreeNode) bool {
	if l == nil && r == nil {
		return true
	}

	if l == nil || r == nil || l.Val != r.Val {
		return false
	}

	return try(l.Left, r.Right) && try(l.Right, l.Left)
}
