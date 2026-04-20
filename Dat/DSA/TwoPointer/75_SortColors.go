package twopointer

// func sortColors(nums []int) {
// 	cnt0, cnt1, cnt2 := 0, 0, 0
// 	for _, v := range nums {
// 		switch v {
// 		case 0:
// 			cnt0++
// 		case 1:
// 			cnt1++
// 		default:
// 			cnt2++
// 		}
// 	}
// 	i := 0
// 	for i < cnt0 {
// 		nums[i] = 0
// 		i++
// 	}
// 	for i < cnt0+cnt1 {
// 		nums[i] = 1
// 		i++
// 	}
// 	for i < cnt0+cnt1+cnt2 {
// 		nums[i] = 2
// 		i++
// 	}
// }

func sortColors(nums []int) {
	l, r := 0, len(nums)-1
	i := 0

	for i <= r {
		switch nums[i] {
		case 0:
			nums[i], nums[l] = nums[l], nums[i]
			i++
			l++
		case 1:
			i++
		default:
			nums[i], nums[r] = nums[r], nums[i]
			r--
		}
	}
}
