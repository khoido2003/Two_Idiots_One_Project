package tree

type BSTreeNode struct {
	Val   int
	Left  *BSTreeNode
	Right *BSTreeNode
}

func (root *BSTreeNode) search(num int) *BSTreeNode {
	for root != nil {
		if root.Val < num {
			root = root.Right
		} else if root.Val > num {
			root = root.Left
		} else {
			return root
		}
	}
	return nil
}

func (root *BSTreeNode) insert(num int) {
	curr := root
	if curr == nil {
		root = &BSTreeNode{
			Val: num,
		}
		return
	}

	var pre *BSTreeNode = nil

	for curr != nil {
		if curr.Val == num {
			return
		}

		pre = curr
		if curr.Val < num {
			curr = curr.Right
		} else {
			curr = curr.Left
		}
	}
	node := &BSTreeNode{
		Val: num,
	}
	if pre.Val < num {
		pre.Right = node
	} else {
		pre.Left = node
	}
}
