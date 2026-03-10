package tree

import (
	"container/list"
)

func LevelOrder(root *TreeNode) [][]int {
	ans := [][]int{}
	queue := list.New()
	queue.PushBack(root)

	for queue.Len() > 0 {
		size, level := queue.Len(), []int{}

		for i := 0; i < size; i++ {
			node := queue.Front().Value.(*TreeNode)
			queue.Remove(queue.Front())

			level = append(level, node.Val)
			if node.Left != nil {
				queue.PushBack(node.Left)
			}
			if node.Right != nil {
				queue.PushBack(node.Right)
			}
		}

		ans = append(ans, level)
	}
	return ans
}
