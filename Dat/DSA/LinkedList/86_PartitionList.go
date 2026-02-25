package linkedlist

func Partition(head *ListNode, x int) *ListNode {
	headLow, headHigh := &ListNode{}, &ListNode{}
	currLow, currHigh := headLow, headHigh

	for head != nil {
		if head.Val < x {
			currLow.Next = head
			currLow = currLow.Next
		} else {
			currHigh.Next = head
			currHigh = currHigh.Next
		}
		head = head.Next
	}

	currLow.Next = headHigh.Next
	currHigh.Next = nil

	return headLow.Next
}
