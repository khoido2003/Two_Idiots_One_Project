package array

func GenerateMatrix(n int) [][]int {
	ans := make([][]int, n)
	for i := range ans {
		ans[i] = make([]int, n)
	}

	t, b, l, r := 0, n-1, 0, n-1
	curr := 1

	for t <= b && l <= r {
		for i := l; i <= r; i++ {
			ans[t][i] = curr
			curr++
		}
		t++

		for i := t; i <= b; i++ {
			ans[i][r] = curr
			curr++
		}
		r--

		if t <= b {
			for i := r; i >= l; i-- {
				ans[b][i] = curr
				curr++
			}
			b--
		}

		if l <= r {
			for i := b; i >= t; i-- {
				ans[i][l] = curr
				curr++
			}
			l++
		}
	}

	return ans
}
