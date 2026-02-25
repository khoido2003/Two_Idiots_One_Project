package hashtable

func CanPermutePalindrome(s string) bool {
	cnt := [26]int{}

	for _, c := range s {
		cnt[c-'a']++
	}
	odd := 0
	for _, x := range cnt {
		odd += x % 2
	}
	return odd < 2
}
