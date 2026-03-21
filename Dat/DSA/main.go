package main

import (
	array "Dat/DSA/Array"
	"fmt"
)

func main() {
	a := []int{10, 1, 2, 7, 6, 1, 5}
	ans := array.CombinationSum2(a, 8)
	fmt.Println(ans)
}
