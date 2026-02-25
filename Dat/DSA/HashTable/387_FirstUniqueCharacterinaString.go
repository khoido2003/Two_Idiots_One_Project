package hashtable

func FirstUniqChar(s string) int {
	mp := map[rune]int{}

	for _, c := range s {
		mp[c]++
	}

	for i, c := range s {
		if mp[c] == 1 {
			return i
		}
	}

	return -1
}
