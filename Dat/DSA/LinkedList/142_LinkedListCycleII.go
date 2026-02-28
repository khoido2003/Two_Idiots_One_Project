package linkedlist

func DetectCycle(head *ListNode) *ListNode {
	mp := map[*ListNode]bool{}

	for head != nil {
		if mp[head] == true {
			return head
		}

		mp[head] = true
		head = head.Next
	}

	return nil
}
