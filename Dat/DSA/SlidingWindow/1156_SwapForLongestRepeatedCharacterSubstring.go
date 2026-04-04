package slidingwindow

type Block struct {
	char byte
	cnt  int
}

func MaxRepOpt1(text string) int {
	mp := map[byte]int{}
	for i := 0; i < len(text); i++ {
		mp[text[i]]++
	}

	blocks := []Block{}
	curr, cnt := text[0], 1
	for i := 1; i < len(text); i++ {
		if text[i] == text[i-1] {
			cnt++
		} else {
			blocks = append(blocks, Block{
				char: curr,
				cnt:  cnt,
			})

			curr = text[i]
			cnt = 1
		}
	}
	blocks = append(blocks, Block{
		char: curr,
		cnt:  cnt,
	})

	ans := blocks[0].cnt
	for i := 0; i < len(blocks); i++ {
		ans = max(ans, blocks[i].cnt)

		// muon them
		if mp[blocks[i].char] > blocks[i].cnt {
			ans = max(ans, blocks[i].cnt+1)
		}

		// 2 chuoi lien nhau
		if i < len(blocks)-2 {
			curr := blocks[i]
			mid := blocks[i+1]
			next := blocks[i+2]
			if curr.char == next.char && mid.cnt == 1 {
				if mp[curr.char] > curr.cnt+next.cnt {
					ans = max(ans, curr.cnt+next.cnt+1)
				} else {
					ans = max(ans, curr.cnt+next.cnt)
				}
			}
		}
	}

	return ans
}
