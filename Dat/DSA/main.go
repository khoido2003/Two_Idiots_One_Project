package main

import (
	twopointer "Dat/DSA/TwoPointer"
	"bufio"
	"fmt"
	"os"
)

var in = bufio.NewReader(os.Stdin)

func main() {
	var n int
	fmt.Fscan(in, &n)

	arr := make([]int, n)
	for i := range arr {
		fmt.Fscan(in, &arr[i])
	}

	ans := twopointer.ThreeSum(arr)
	fmt.Println(ans)

}
