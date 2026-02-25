package linkedlist

import "fmt"

type ListNode struct {
	Val  int
	Next *ListNode
}

func FromSlice(val []int) *ListNode {
	if len(val) == 0 {
		return nil
	}
	head := &ListNode{}
	cur := head
	for _, v := range val {
		cur.Next = &ListNode{Val: v}
		cur = cur.Next
	}
	return head.Next
}

func Print(head *ListNode) {
	cur := head
	for cur != nil {
		fmt.Print(cur.Val, " ")
		cur = cur.Next
	}
}
