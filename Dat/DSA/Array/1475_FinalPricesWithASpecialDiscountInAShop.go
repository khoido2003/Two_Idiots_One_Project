package array

func finalPrices(prices []int) []int {
	ans := make([]int, len(prices))
	copy(ans, prices)

	for i := range prices {
		for j := i + 1; j < len(prices); j++ {
			if prices[j] <= prices[i] {
				ans[i] = prices[i] - prices[j]
				break
			}
		}
	}

	return ans
}

// Stack way
func finalPrices2(prices []int) []int {
	st := []int{}

	for i := range prices {
		for len(st) > 0 && prices[st[len(st)-1]] >= prices[i] {
			prices[st[len(st)-1]] -= prices[i]
			st = st[:len(st)-1]
		}
		st = append(st, i)
	}
	return prices
}
