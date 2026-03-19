package tree

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func FromSlice(arr []int) *TreeNode {
	if len(arr) == 0 || arr[0] == -1 {
		return nil
	}

	root := &TreeNode{Val: arr[0]}
	queue := []*TreeNode{root}
	i := 1

	for len(queue) > 0 && i < len(arr) {
		node := queue[0]
		queue = queue[1:]

		// left child
		if i < len(arr) {
			if arr[i] != -1 {
				node.Left = &TreeNode{Val: arr[i]}
				queue = append(queue, node.Left)
			}
			i++
		}

		// right child
		if i < len(arr) {
			if arr[i] != -1 {
				node.Right = &TreeNode{Val: arr[i]}
				queue = append(queue, node.Right)
			}
			i++
		}
	}

	return root
}
