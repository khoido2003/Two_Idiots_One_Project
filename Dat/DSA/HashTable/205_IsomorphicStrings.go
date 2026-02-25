package hashtable

func IsIsomorphic(s string, t string) bool {
	sMap, tMap := map[rune]rune{}, map[rune]rune{}
	sRunes, tRunes := []rune(s), []rune(t)

	for i := range sRunes {
		a, b := sRunes[i], tRunes[i]

		if sMap[a] != 0 && sMap[a] != b {
			return false
		}
		if tMap[b] != 0 && tMap[b] != a {
			return false
		}

		sMap[a] = b
		tMap[b] = a
	}
	return true
}
