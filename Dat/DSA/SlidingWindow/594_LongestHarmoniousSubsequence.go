package slidingwindow

import "slices"

// func findLHS(nums []int) int {
// 	mp := map[int]int{}
// 	for _, val := range nums {
// 		mp[val]++
// 	}

// 	ans := 0
// 	for _, val := range nums {
// 		if mp[val+1] != 0 {
// 			ans = max(ans, mp[val]+mp[val+1])
// 		}
// 	}
// 	return ans
// }

func findLHS(nums []int) int {
	slices.Sort(nums)
	i, j, ans := 0, 1, 0
	for j < len(nums) {
		if nums[j]-nums[i] == 1 {
			ans = max(ans, j-i+1)
			j++
		} else if nums[j]-nums[i] < 1 {
			j++
		} else {
			i++

			if i == j {
				j++
			}
		}
	}
	return ans
}
