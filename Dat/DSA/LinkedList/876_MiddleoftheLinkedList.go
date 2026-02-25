package linkedlist

func MiddleNode(head *ListNode) *ListNode {
	a, b := head, head

	for b != nil && b.Next != nil {
		a = a.Next
		b = b.Next.Next
	}

	return a
}
