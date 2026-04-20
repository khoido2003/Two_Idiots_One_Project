package twopointer

func findKDistantIndices(nums []int, key int, k int) []int {
	n := len(nums)
	ans := []int{}
	prev := -1
	for i, v := range nums {
		if v == key {
			start, end := max(0, i-k, prev+1), min(n-1, i+k)
			for j := start; j <= end; j++ {
				ans = append(ans, j)
				prev = j
			}
		}
	}
	return ans
}
