package array

func PermuteUnique(nums []int) [][]int {
	res := [][]int{}

	var dfs func(x int)

	dfs = func(x int) {
		if x == len(nums)-1 {
			tmp := make([]int, len(nums))
			copy(tmp, nums)
			res = append(res, tmp)
			return
		}

		mp := map[int]bool{}
		for i := x; i < len(nums); i++ {
			if mp[nums[i]] == true {
				continue
			}
			mp[nums[i]] = true

			nums[i], nums[x] = nums[x], nums[i]
			dfs(x + 1)
			nums[i], nums[x] = nums[x], nums[i]
		}
	}

	dfs(0)
	return res

}
