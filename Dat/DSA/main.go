package main

import (
	tree "Dat/DSA/Tree"
	"fmt"
)

func main() {
	// arr := tree.FromSlice([]int{5, 4, 8, 11, -1, 13, 4, 7, 2, -1, -1, 5, 1})

	arr := tree.FromSlice([]int{1, 2})

	ans := tree.LevelOrder(arr)
	fmt.Println(ans)

	res := tree.PathSum2(arr, 1)
	fmt.Println(res)
}
