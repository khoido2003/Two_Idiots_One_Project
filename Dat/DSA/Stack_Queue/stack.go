package stackqueue

type Stack struct {
	elements []int
}

func (s *Stack) Push(ele int) {
	s.elements = append(s.elements, ele)
}

func (s *Stack) Pop() (int, bool) {
	if len(s.elements) == 0 {
		return 0, false
	}

	data := s.elements[len(s.elements)-1]
	s.elements = s.elements[:len(s.elements)-1]

	return data, true
}

func (s *Stack) Peek() int {
	data := s.elements[len(s.elements)-1]
	return data
}
