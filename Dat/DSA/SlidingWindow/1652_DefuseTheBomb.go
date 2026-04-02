package slidingwindow

func decrypt(code []int, k int) []int {
	n := len(code)
	res := make([]int, n)
	if k == 0 {
		return res
	}

	var l, r int
	if k > 0 {
		l, r = 1, k
	} else {
		l, r = n+k, n-1
	}
	for i := l; i <= r; i++ {
		res[0] += code[i]
	}

	for i := 1; i < n; i++ {
		res[i] = res[i-1] - code[l] + code[(r+1)%n]
		l, r = (l+1)%n, (r+1)%n
	}

	return res
}
