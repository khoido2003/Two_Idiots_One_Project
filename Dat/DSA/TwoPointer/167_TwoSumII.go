package twopointer

func TwoSum(numbers []int, target int) []int {
	i, j := 0, len(numbers)-1

	for i < j {
		s := numbers[i] + numbers[j]

		if s > target {
			j -= 1
		} else if s < target {
			i += 1
		} else {
			return []int{i + 1, j + 1}
		}
	}

	return []int{-1, -1}

}
