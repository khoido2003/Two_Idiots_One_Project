package linkedlist

import (
	"fmt"
)

type RandomNode struct {
	Val    int
	Next   *RandomNode
	Random *RandomNode
}

func FromArray(arr [][]int) *RandomNode {
	if len(arr) == 0 {
		return nil
	}

	nodes := make([]*RandomNode, len(arr))
	for i := range arr {
		nodes[i] = &RandomNode{Val: arr[i][0]}
	}

	for i := 0; i < len(arr)-1; i++ {
		nodes[i].Next = nodes[i+1]
	}
	for i := range arr {
		r := arr[i][1]
		if r >= 0 {
			nodes[i].Random = nodes[r]
		}
	}
	return nodes[0]
}

func PrintRandomNode(head *RandomNode) {
	cur := head
	for cur != nil {
		fmt.Println(cur.Val, " ", cur.Next, " ", cur.Random)
		cur = cur.Next
	}
}

func CopyRandomList(head *RandomNode) *RandomNode {
	m := make(map[*RandomNode]*RandomNode)

	cur := head
	for cur != nil {
		n := &RandomNode{
			Val: cur.Val,
		}
		m[cur] = n
		cur = cur.Next
	}

	cur = head
	for cur != nil {
		m[cur].Next = m[cur.Next]
		m[cur].Random = m[cur.Random]
		cur = cur.Next
	}

	return m[head]

}
