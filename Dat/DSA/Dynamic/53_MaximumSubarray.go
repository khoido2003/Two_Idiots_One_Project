package dynamic

func MaxSubArray(nums []int) (int, int, int) {
	currSum, bestSum := 0, nums[0]
	tmpStart := 0
	bestStart, bestEnd := 0, 0
	for i, v := range nums {
		if currSum <= 0 {
			currSum = v
			tmpStart = i
		} else {
			currSum += v
		}

		if currSum > bestSum {
			bestSum = currSum
			bestStart = tmpStart
			bestEnd = i
		}
	}
	return bestSum, bestStart, bestEnd
}
