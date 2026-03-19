package array

func SpiralOrder(matrix [][]int) []int {
	res := []int{}

	t, b, l, r := 0, len(matrix)-1, 0, len(matrix[0])-1

	for t <= b && l <= r {
		for i := l; i <= r; i++ {
			res = append(res, matrix[t][i])
		}
		t++

		for i := t; i <= b; i++ {
			res = append(res, matrix[i][r])
		}
		r--

		if t <= b {
			for i := r; i >= l; i-- {
				res = append(res, matrix[b][i])
			}
			b--
		}

		if l <= r {
			for i := b; i >= t; i-- {
				res = append(res, matrix[i][l])
			}
			l++
		}
	}

	return res
}
