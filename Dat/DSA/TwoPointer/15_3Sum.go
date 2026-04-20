package twopointer

import "slices"

func ThreeSum(nums []int) [][]int {
	ans := [][]int{}

	slices.Sort(nums)

	for a := 0; a < len(nums)-2; a++ {
		if a > 0 && nums[a] == nums[a-1] {
			continue
		}
		b, c := a+1, len(nums)-1
		for b < c {
			s := nums[a] + nums[b] + nums[c]
			if s == 0 {
				ans = append(ans, []int{nums[a], nums[b], nums[c]})
				// skip duplicates
				for b < c && nums[b] == nums[b+1] {
					b++
				}
				for b < c && nums[c] == nums[c-1] {
					c--
				}
				b++
				c--
			} else if s < 0 {
				b++
			} else {
				c--
			}
		}
	}
	return ans
}
