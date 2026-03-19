package array

import "container/heap"

func findKthLargest(nums []int, k int) int {
	minHeap := &MinHeap{}
	heap.Init(minHeap)

	for _, num := range nums {
		heap.Push(minHeap, num)

		if minHeap.Len() > k {
			heap.Pop(minHeap)
		}
	}

	return (*minHeap)[0]
}
