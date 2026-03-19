package string

func AddStrings(num1 string, num2 string) string {
	maxLen := max(len(num1), len(num2))
	for len(num1) < maxLen {
		num1 = "0" + num1
	}
	for len(num2) < maxLen {
		num2 = "0" + num2
	}
	s1, s2 := []rune(num1), []rune(num2)
	ans := make([]byte, maxLen)
	cnt := 0
	for i := maxLen - 1; i >= 0; i-- {
		sum := cnt + int(s1[i]-'0') + int(s2[i]-'0')
		ans[i] = byte(sum%10) + '0'
		cnt = sum / 10
	}

	if cnt > 0 {
		newAns := make([]byte, maxLen+1)
		newAns[0] = byte(cnt) + '0'
		copy(newAns[1:], ans)
		return string(newAns)
	}

	return string(ans)
}

func addStrings2(num1 string, num2 string) string {
	i, j := len(num1)-1, len(num2)-1
	carry := 0
	var ans []byte
	for i >= 0 || j >= 0 || carry > 0 {
		sum := carry

		if i >= 0 {
			sum += int(num1[i] - '0')
			i--
		}
		if j >= 0 {
			sum += int(num2[i] - '0')
			j--
		}
		ans = append(ans, byte(sum%10)+'0')
		carry = sum / 10
	}

	for l, r := 0, len(ans)-1; l < r; l, r = l+1, r-1 {
		ans[l], ans[r] = ans[r], ans[l]
	}

	return string(ans)
}
