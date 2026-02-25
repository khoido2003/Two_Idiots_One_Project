package stackqueue

func IsValid(s string) bool {
	tmp := []rune{}

	pairs := map[rune]rune{
		')': '(',
		']': '[',
		'}': '{',
	}

	for _, c := range s {
		if c == '(' || c == '[' || c == '{' {
			tmp = append(tmp, c)
		} else {
			if len(tmp) == 0 || tmp[len(tmp)-1] != pairs[c] {
				return false
			}
			tmp = tmp[:len(tmp)-1]
		}
	}

	return len(tmp) != 0
}
