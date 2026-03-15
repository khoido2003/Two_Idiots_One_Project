package stackqueue

import "strconv"

func evalRPN(tokens []string) int {
	mp := map[string]bool{
		"+": true,
		"-": true,
		"*": true,
		"/": true,
	}
	st := []int{}

	for _, token := range tokens {
		if mp[token] == true {
			a, b := st[len(st)-2], st[len(st)-1]
			st = st[:len(st)-2]
			if token == "+" {
				st = append(st, a+b)
			} else if token == "-" {
				st = append(st, a-b)
			} else if token == "*" {
				st = append(st, a*b)
			} else if token == "/" {
				st = append(st, a/b)
			}

		} else {
			num, _ := strconv.Atoi(token)
			st = append(st, num)
		}
	}

	return st[len(st)-1]
}
