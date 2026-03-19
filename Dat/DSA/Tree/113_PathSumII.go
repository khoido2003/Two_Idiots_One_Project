package tree

func PathSumII(root *TreeNode, targetSum int) [][]int {
	ans := [][]int{}

	var backtrack func(root *TreeNode, currArr []int, currSum int)

	backtrack = func(root *TreeNode, currArr []int, currSum int) {
		if root == nil {
			return
		}

		currArr = append(currArr, root.Val)
		currSum += root.Val

		if root.Left == nil && root.Right == nil && currSum == targetSum {
			tmp := make([]int, len(currArr))
			copy(tmp, currArr)
			ans = append(ans, tmp)
		}

		backtrack(root.Left, currArr, currSum)
		backtrack(root.Right, currArr, currSum)
	}

	backtrack(root, []int{}, 0)

	return ans

}
