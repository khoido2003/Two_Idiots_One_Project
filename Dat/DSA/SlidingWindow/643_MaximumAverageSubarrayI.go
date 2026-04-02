package slidingwindow

func findMaxAverage(nums []int, k int) float64 {
	sum := 0.0
	for i := 0; i < k; i++ {
		sum += float64(nums[i])
	}

	ans := sum / float64(k)
	for i := 1; i <= len(nums)-k; i++ {
		sum = sum - float64(nums[i-1]) + float64(nums[k+i-1])
		ans = max(ans, sum/float64(k))
	}
	return ans
}
