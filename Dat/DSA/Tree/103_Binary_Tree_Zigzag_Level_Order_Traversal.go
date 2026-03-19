package tree

import (
	"container/list"
)

func ZigzagLevelOrder(root *TreeNode) [][]int {
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

	for i := 0; i < len(ans); i++ {
		if i%2 == 1 {
			ans[i] = reverse(ans[i])
		}
	}

	return ans
}

func reverse(arr []int) []int {
	for i, j := 0, len(arr)-1; i <= j; i, j = i+1, j-1 {
		arr[i], arr[j] = arr[j], arr[i]
	}
	return arr
}
