package slidingwindow

type PrimeInfo struct {
	Val int
	Idx int
}

func primeSubarray(nums []int, k int) int {
	n := len(nums)
	if n == 0 {
		return 0
	}

	maxVal := 0
	for _, val := range nums {
		maxVal = max(val, maxVal)
	}

	// sang so nguyen to
	isPrime := make([]bool, maxVal+1)
	for i := 2; i <= maxVal; i++ {
		isPrime[i] = true
	}
	for i := 2; i*i <= maxVal; i++ {
		if isPrime[i] {
			for j := i * i; j <= maxVal; j += i {
				isPrime[j] = false
			}
		}
	}

	// Filter -> {Val, Index}
	primes := []PrimeInfo{}
	for i, v := range nums {
		if v >= 2 && isPrime[v] {
			primes = append(primes, PrimeInfo{
				Val: v,
				Idx: i,
			})
		}
	}
	if len(primes) < 2 {
		return 0
	}

	totalCnt, left := 0, 0
	maxQueue, minQueue := []int{}, []int{}
	for right := 0; right < len(primes); right++ {
		// DEQUEUE
		for len(maxQueue) > 0 && primes[getFirst(maxQueue)].Val <= primes[right].Val {
			maxQueue = maxQueue[:len(maxQueue)-1]
		}
		maxQueue = append(maxQueue, right)

		for len(minQueue) > 0 && primes[getFirst(minQueue)].Val >= primes[right].Val {
			minQueue = minQueue[:len(minQueue)-1]
		}
		minQueue = append(minQueue, right)

		// Thu hẹp cửa sổ nếu Gap > k
		for primes[maxQueue[0]].Val-primes[minQueue[0]].Val > k {
			left++
			if maxQueue[0] < left {
				maxQueue = maxQueue[1:]
			}
			if minQueue[0] < left {
				minQueue = minQueue[1:]
			}
		}

		// CORE LOGIC
		if right > left {
			// Điểm bắt đầu L: Từ sau vị trí của P[left-1] đến vị trí của P[right-1]
			idxLeft := -1
			if left > 0 {
				idxLeft = primes[left-1].Idx
			}
			wayToStart := primes[right-1].Idx - idxLeft

			// Điểm kết thúc R: Từ vị trí của P[right] đến trước vị trí của P[right+1]
			idxRight := n
			if right+1 < len(primes) {
				idxRight = primes[right+1].Idx
			}
			wayToEnd := idxRight - primes[right].Idx

			totalCnt += wayToStart * wayToEnd
		}
	}
	return totalCnt
}

func getFirst(nums []int) int {
	return nums[len(nums)-1]
}
