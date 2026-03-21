package main

import (
	"bufio"
	"fmt"
	"math"
	"os"
	"slices"
	"sort"
	"strconv"
	// "slices"
	// "sort"
)

// init: go mod init project-name
// create main.go: func main(){}

var in = bufio.NewReader(os.Stdin)

func main() {
	// ---------------------------------------------------------------
	// IO handler
	// 1.1 Read single input (also with float, string: 1 world only, bool)
	var n int
	fmt.Fscan(in, &n)

	arr := make([]int, n)
	for i := 0; i < n; i++ {
		fmt.Fscan(in, &arr[i])
	}
	fmt.Println(arr)

	//// 1.2. Read whole line
	// in.ReadString('\n') // consume leftover newline
	// line, _ := in.ReadString('\n')
	// fmt.Println(line)

	// 1.3.Read until EOF
	// for {
	// 	var x int
	// 	_, err := fmt.Fscan(in, &x)
	// 	if err != nil {
	// 		break
	// 	}
	// 	fmt.Println(x)
	// }

	// ---------------------------------------------------------------
	// Sort
	sort.Ints(arr)
	fmt.Println("sort1", arr)
	// slices.Sort(arr)
	// sort.Strings(arr)

	// custom sort
	slices.SortFunc(arr, func(a, b int) int {
		return b - a
	})
	fmt.Println("Sort2", arr)

	// ---------------------------------------------------------------
	// String
	s := "123"
	num, _ := strconv.Atoi(s) // string to int
	s = strconv.Itoa(num)     // int to string

	// Math
	math.Sqrt(16)
	// math.MaxInt

	// slices
	slice := []int{1, 2, 3, 4}
	i := 1
	slice = append(slice[:i], slice[i+1:]...)
	// copy
	// b := make([]int, len(arr))
	// copy(b, arr)
	// slices.Reverse(slice)

}
