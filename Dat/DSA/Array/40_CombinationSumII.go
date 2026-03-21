package array

import (
	"fmt"
	"sort"
)

func CombinationSum2(candidates []int, target int) [][]int {
	sort.Ints(candidates)
	fmt.Println(candidates)
	ans := [][]int{}

	var bt func(currIdx int, curArr []int, sum int)

	bt = func(currIdx int, curArr []int, sum int) {
		if sum > target {
			return
		}

		if sum == target {
			tmp := make([]int, len(curArr))
			copy(tmp, curArr)
			ans = append(ans, tmp)
			return
		}

		for i := currIdx; i < len(candidates); i++ {
			if i > currIdx && candidates[i] == candidates[i-1] {
				continue
			}

			if sum+candidates[i] > target {
				break
			}

			curArr = append(curArr, candidates[i])
			sum += candidates[i]

			bt(i+1, curArr, sum)

			curArr = curArr[:len(curArr)-1]
			sum -= candidates[i]
		}
	}

	bt(0, []int{}, 0)

	return ans
}
