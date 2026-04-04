package slidingwindow

func minimumRecolors(blocks string, k int) int {
	cntW := 0
	for i := 0; i < k; i++ {
		if blocks[i] == 'W' {
			cntW++
		}
	}
	ans := min(k, cntW)

	for i := 1; i <= len(blocks)-k; i++ {
		if blocks[i+k-1] == 'W' {
			cntW++
		}
		if blocks[i-1] == 'W' {
			cntW--
		}

		ans = min(ans, cntW)
	}

	return ans
}
