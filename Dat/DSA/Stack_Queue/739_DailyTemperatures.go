package stackqueue

func DailyTemperatures(temperatures []int) []int {
	ans := make([]int, len(temperatures))
	s := Stack{}

	for i := range temperatures {
		for len(s.elements) > 0 && temperatures[s.Peek()] < temperatures[i] {
			ans[s.Peek()] = i - s.Peek()
			s.Pop()
		}
		s.Push(i)
	}

	return ans
}
