package stackqueue

func DecodeString(s string) string {
	countStack := []int{}
	stringStack := []string{}
	res := ""
	multi := 0

	for _, c := range s {
		if c == '[' {
			countStack = append(countStack, multi)
			stringStack = append(stringStack, res)
			res = ""
			multi = 0
		} else if c == ']' {
			curMulti := countStack[len(countStack)-1]
			countStack = countStack[:len(countStack)-1]

			lastRes := stringStack[len(stringStack)-1]
			stringStack = stringStack[:len(stringStack)-1]

			tmp := ""
			for i := 0; i < curMulti; i++ {
				tmp += res
			}

			res = lastRes + tmp
		} else if '0' <= c && c <= '9' {
			multi = multi*10 + int(c-'0')

		} else {
			res += string(c)
		}
	}
	return res
}
