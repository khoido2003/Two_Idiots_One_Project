package twopointer

import (
	"slices"
)

func findMaxK(nums []int) int {
	slices.Sort(nums)

	i, j := 0, len(nums)-1
	for i < j {
		if nums[i]+nums[j] == 0 {
			return nums[j]
		} else if nums[i]+nums[j] < 0 {
			i++
		} else {
			j--
		}
	}
	return -1
}
