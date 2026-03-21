package stackqueue

func buildArray(target []int, n int) []string {
	ans := []string{}
	stack := []int{}
	stackTop := -1

	for i := 1; i <= n; i++ {
		stack = append(stack, i)
		stackTop++
		ans = append(ans, "Push")

		if stack[stackTop] != target[stackTop] {
			stack = stack[:len(stack)-1]
			stackTop--
			ans = append(ans, "Pop")
		}

		if stackTop == len(target)-1 {
			break
		}
	}

	return ans
}
