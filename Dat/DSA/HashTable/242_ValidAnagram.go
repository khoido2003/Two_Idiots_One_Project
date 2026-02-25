package hashtable

func IsAnagram(s string, t string) bool {
	if len(s) != len(t) {
		return false
	}

	mp := map[rune]int{}

	for _, c := range s {
		mp[c]++
	}

	for _, c := range t {
		if mp[c] == 0 {
			return false
		}
		mp[c]--
	}

	return true
}
