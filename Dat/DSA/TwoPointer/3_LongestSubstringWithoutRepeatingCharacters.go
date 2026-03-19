package twopointer

func LengthOfLongestSubstring(s string) int {
	mp := map[byte]bool{}
	i, j := 0, 0
	ans := 0

	for j < len(s) {
		for mp[s[j]] {
			mp[s[i]] = false
			i++
		}
		mp[s[j]] = true
		if ans < j-i+1 {
			ans = j - i + 1
		}
		j++
	}

	return ans
}

func lengthOfLongestSubstring(s string) int {
	mp := map[byte]int{}
	i := -1
	res := 0

	for j := 0; j < len(s); j++ {
		if pos, ok := mp[s[j]]; ok {
			if pos > i {
				i = pos
			}
		}
		mp[s[j]] = j
		if res < j-i {
			res = j - i
		}
	}

	return res
}
