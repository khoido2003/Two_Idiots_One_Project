package main

import (
	dynamic "Dat/DSA/Dynamic"
	"fmt"
)

func main() {
	// var in = bufio.NewReader(os.Stdin)

	// var n, t int
	// fmt.Fscan(in, &t)

	// for t > 0 {
	// 	t--
	// 	fmt.Fscan(in, &n)
	// 	arr := make([]int, n)
	// 	for i := 0; i < n; i++ {
	// 		fmt.Fscan(in, &arr[i])
	// 	}
	// 	ans := dynamic.RunningSum(arr)
	// 	fmt.Println(arr, "->", ans)
	// }

	arr := []int{
		-2, 1, -3, 4, -1, 2, 1, -5, 4,
	}
	a, b, c := dynamic.MaxSubArray(arr)
	fmt.Println(a, b, c)
}
