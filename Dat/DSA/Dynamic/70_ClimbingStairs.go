package dynamic

func ClimbStairs(n int) int {
	res := make([]int, n)
	res[0] = 1
	res[1] = 2
	for i := 2; i < n; i++ {
		res[i] = res[i-1] + res[i-2]
	}
	return res[n-1]
}
