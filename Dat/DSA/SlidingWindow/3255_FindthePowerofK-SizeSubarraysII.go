package slidingwindow

func resultsArray(nums []int, k int) []int {
	if k == 1 {
		return nums
	}

	ans := []int{}

	cnt := 1
	for i := 1; i < len(nums); i++ {
		if nums[i]-nums[i-1] == 1 {
			cnt++
		} else {
			cnt = 1
		}

		if i >= k-1 {
			if cnt >= k {
				ans = append(ans, nums[i])
			} else {
				ans = append(ans, -1)
			}
		}
	}
	return ans
}
