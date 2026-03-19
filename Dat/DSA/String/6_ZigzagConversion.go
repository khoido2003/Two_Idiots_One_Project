package string

// PAYPALISHIRING
func Convert(s string, numRows int) string {
	if numRows <= 1 || numRows >= len(s) {
		return s
	}
	arr := make([][]rune, numRows)
	for i := range arr {
		arr[i] = make([]rune, len(s))
	}

	i, j := 0, 0
	full := false
	for _, c := range s {
		arr[i][j] = c

		if i == numRows-1 {
			full = true
		} else if i == 0 {
			full = false
		}

		if full {
			i--
			j++
		} else {
			i++
		}
	}
	var ans []rune
	for _, a := range arr {
		for _, c := range a {
			if c != 0 {
				ans = append(ans, c)
			}
		}
	}

	return string(ans)
}
