package stackqueue

func largestRectangleArea(heights []int) int {
	n := len(heights)
	left, right := make([]int, n), make([]int, n)
	st := Stack{}

	// left nearest
	for i := 0; i < n; i++ {
		for len(st.elements) > 0 && heights[st.Peek()] >= heights[i] {
			st.Pop()
		}
		if len(st.elements) == 0 {
			left[i] = -1
		} else {
			left[i] = st.Peek()
		}
		st.Push(i)
	}

	clear(st.elements)

	// right nearest
	for i := n - 1; i >= 0; i-- {
		for len(st.elements) > 0 && heights[st.Peek()] >= heights[i] {
			st.Pop()
		}
		if len(st.elements) == 0 {
			right[i] = n
		} else {
			right[i] = st.Peek()
		}
		st.Push(i)
	}

	maxAns := 0
	for i := 0; i < n; i++ {
		width := right[i] - left[i] - 1
		maxAns = max(maxAns, width*heights[i])
	}
	return maxAns
}
