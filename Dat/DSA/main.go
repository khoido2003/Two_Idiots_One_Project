package main

import (
	slidingwindow "Dat/DSA/SlidingWindow"
	"bufio"
	"fmt"
	"os"
)

var in = bufio.NewReader(os.Stdin)

func main() {
	// var n, k int
	// fmt.Fscan(in, &n, &k)

	// arr := make([]int, n)
	// for i := range arr {
	// 	fmt.Fscan(in, &arr[i])
	// }
	ans := slidingwindow.MaxRepOpt1("ababa")
	fmt.Println(ans)
}
