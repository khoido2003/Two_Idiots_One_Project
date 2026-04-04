package slidingwindow

func maximumLengthSubstring(s string) int {
	mp := map[byte]int{}
	i, j := 0, 1
	mp[s[0]] = 1
	ans := 0

	for j < len(s) {
		mp[s[j]]++

		if mp[s[j]] > 2 {
			for mp[s[j]] > 2 {
				mp[s[i]]--
				i++
			}
		} else {
			ans = max(ans, j-i+1)
		}
		j++
	}
	return ans
}
