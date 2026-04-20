package twopointer

import "slices"

func triangleNumber(nums []int) int {
	slices.Sort(nums)
	cnt := 0

	for i := len(nums) - 1; i >= 2; i-- {
		l, r := 0, i-1
		for l < r {
			if nums[l]+nums[r] > nums[i] {
				cnt += r - l
				r--
			} else {
				l++
			}
		}
	}
	return cnt
}
