package dynamic

func rob2(nums []int) int {
	if len(nums) == 1 {
		return nums[0]
	}
	if len(nums) == 2 {
		return max(nums[0], nums[1])
	}

	a := nums[:len(nums)-1]
	b := nums[1:]
	return max(Rob(a), Rob(b))
}
