package dynamic

import "fmt"

func MinPathSum(grid [][]int) int {
	sum, _ := MinPathSumWithPath(grid)
	return sum
}

func MinPathSumWithPath(grid [][]int) (int, []int) {
	if len(grid) == 0 || len(grid[0]) == 0 {
		return 0, nil
	}

	m, n := len(grid), len(grid[0])
	res := make([][]int, m)
	parent := make([][][2]int, m)

	for i := 0; i < m; i++ {
		res[i] = make([]int, n)
		parent[i] = make([][2]int, n)
	}

	res[0][0] = grid[0][0]
	parent[0][0] = [2]int{-1, -1}
	for i := 1; i < n; i++ {
		res[0][i] = res[0][i-1] + grid[0][i]
		parent[0][i] = [2]int{0, i - 1}
	}
	for i := 1; i < m; i++ {
		res[i][0] = res[i-1][0] + grid[i][0]
		parent[i][0] = [2]int{i - 1, 0}
	}

	for i := 1; i < m; i++ {
		for j := 1; j < n; j++ {
			if res[i-1][j] <= res[i][j-1] {
				res[i][j] = res[i-1][j] + grid[i][j]
				parent[i][j] = [2]int{i - 1, j}
			} else {
				res[i][j] = res[i][j-1] + grid[i][j]
				parent[i][j] = [2]int{i, j - 1}
			}
		}
	}

	fmt.Println(parent)

	path := make([]int, 0, m+n-1)
	for i, j := m-1, n-1; i >= 0 && j >= 0; {
		path = append(path, grid[i][j])
		p := parent[i][j]
		if p[0] == -1 && p[1] == -1 {
			break
		}
		i, j = p[0], p[1]
	}

	fmt.Println(path)

	for left, right := 0, len(path)-1; left < right; left, right = left+1, right-1 {
		path[left], path[right] = path[right], path[left]
	}

	return res[m-1][n-1], path
}
