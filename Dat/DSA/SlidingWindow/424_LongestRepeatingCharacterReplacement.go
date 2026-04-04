package slidingwindow

func characterReplacement(s string, k int) int {
	mp := map[byte]int{}
	maxFreq := 0
	i, ans := 0, 0

	for j := 0; j < len(s); j++ {
		mp[s[j]]++
		maxFreq = max(maxFreq, mp[s[j]])

		// so phan tu can thay the > k -> thu left lai
		for j-i+1-maxFreq > k {
			mp[s[i]]--
			i++
		}
		ans = max(ans, j-i+1)
	}
	return ans
}
