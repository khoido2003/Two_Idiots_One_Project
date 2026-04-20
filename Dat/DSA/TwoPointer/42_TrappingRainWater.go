package twopointer

func trap(height []int) int {
	n := len(height)
	maxL := make([]int, n)
	maxR := make([]int, n)

	maxL[0] = height[0]
	for i := 0; i < len(height); i++ {
		maxL[i] = max(maxL[i-1], height[i])
	}

	maxR[n-1] = height[n-1]
	for i := n - 2; i >= 0; i-- {
		maxR[i] = max(maxR[i+1], height[i])
	}

	ans := 0
	for i := 0; i < len(height); i++ {
		ans += min(maxL[i], maxR[i]) - height[i]
	}
	return ans
}
