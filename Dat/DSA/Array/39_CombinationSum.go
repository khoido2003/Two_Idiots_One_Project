package array

func CombinationSum(candidates []int, target int) [][]int {
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
			curArr = append(curArr, candidates[i])
			sum += candidates[i]

			bt(i, curArr, sum)

			curArr = curArr[:len(curArr)-1]
			sum -= candidates[i]
		}
	}

	bt(0, []int{}, 0)

	return ans
}
