package slidingwindow

import (
	"math"
	"slices"
)

func minimumDifference(nums []int, k int) int {
	slices.Sort(nums)
	if len(nums) == 1 {
		return 0
	}

	ans := math.MaxInt
	for i := 0; i <= len(nums)-k; i++ {
		ans = min(ans, nums[i+k-1]-nums[i])
	}
	return ans
}
