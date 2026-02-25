package main

import (
	twopointer "Dat/DSA/TwoPointer"
	"fmt"
)

func main() {
	s, t := "abc", "ahbgdc"
	ans := twopointer.IsSubsequence(s, t)
	fmt.Println(ans)
}
