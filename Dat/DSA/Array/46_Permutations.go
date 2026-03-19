package array

func permute(nums []int) [][]int {
	res := [][]int{}

	var backtrack func(path []int)
	backtrack = func(path []int) {
		if len(path) == len(nums) {
			tmp := make([]int, len(nums))
			copy(tmp, path)
			res = append(res, tmp)
		}

		for _, n := range nums {
			if contains(path, n) {
				continue
			}

			path = append(path, n)
			backtrack(path)
			path = path[:len(path)-1]
		}
	}

	return res
}

func contains(arr []int, target int) bool {
	for _, v := range arr {
		if v == target {
			return true
		}
	}
	return false
}

func Permute2(nums []int) [][]int {
	res := [][]int{}

	var dfs func(x int)

	dfs = func(x int) {
		if x == len(nums)-1 {
			tmp := make([]int, len(nums))
			copy(tmp, nums)
			res = append(res, tmp)
			return
		}

		for i := x; i < len(nums); i++ {
			nums[i], nums[x] = nums[x], nums[i]
			dfs(x + 1)
			nums[i], nums[x] = nums[x], nums[i]
		}
	}

	dfs(0)
	return res
}
