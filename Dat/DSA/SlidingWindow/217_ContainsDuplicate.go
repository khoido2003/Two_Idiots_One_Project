package slidingwindow

func containsDuplicate(nums []int) bool {
	mp := map[int]bool{}

	for _, val := range nums {
		if mp[val] == true {
			return false
		}
		mp[val] = true
	}
	return true
}
