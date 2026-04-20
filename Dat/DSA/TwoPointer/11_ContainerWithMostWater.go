package twopointer

func maxArea(height []int) int {
	i, j := 0, len(height)-1
	ans := 0

	for i < j {
		h := min(height[i], height[j])
		w := j - i
		ans = max(ans, h*w)

		if height[i] > height[j] {
			j--
		} else {
			i++
		}
	}
	return ans
}
