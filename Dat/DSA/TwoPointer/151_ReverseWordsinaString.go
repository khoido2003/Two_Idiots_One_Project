package twopointer

import (
	"strings"
)

func reverse(s string) string {
	chars := []rune(s)
	for i, j := 0, len(chars)-1; i < j; i, j = i+1, j-1 {
		chars[i], chars[j] = chars[j], chars[i]
	}
	return string(chars)
}

func ReverseWords(s string) string {
	s1 := reverse(strings.Trim(s, " "))
	words := strings.Fields(s1)

	for i := 0; i < len(words); i++ {
		words[i] = reverse(words[i])
	}

	return strings.Join(words, " ")
}
