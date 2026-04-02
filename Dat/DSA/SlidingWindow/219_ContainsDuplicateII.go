package slidingwindow

import "fmt"

func ContainsNearbyDuplicate(nums []int, k int) bool {
	mp := map[int]int{}

	for i, val := range nums {
		j := mp[val]
		if j != 0 {
			fmt.Println(j, i)
			if i-j+1 <= k {
				return true
			}
		}
		mp[val] = i + 1
	}
	return false
}
