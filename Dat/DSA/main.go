package main

import (
	tree "Dat/DSA/Tree"
	"fmt"
)

func main() {
	arr := tree.FromSlice([]int{3, 5, 1, 6, 2, 0, 8, -1, -1, 7, 4})

	ans := tree.LevelOrder(arr)
	fmt.Println(ans)
}
