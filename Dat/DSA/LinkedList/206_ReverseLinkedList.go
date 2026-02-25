package linkedlist

func ReverseList(head *ListNode) *ListNode {
	var prev, tmp *ListNode
	for head != nil {
		tmp = head.Next
		head.Next = prev
		prev = head
		head = tmp
	}

	return prev
}
