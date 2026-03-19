package graph

// Purpose: check a graph (DAG - Direct Acyclic Graph) is cycle or not
// BFS: in-degree (make graph using adjacency list + in-degree)
// if not cycle: always have node have indgree = 0

// DFS: visited

func canFinishBFS(numCourses int, prerequisites [][]int) bool {
	adjacency := make([][]int, numCourses)
	indgree := make([]int, numCourses)

	for _, p := range prerequisites {
		course, pre := p[0], p[1]
		adjacency[pre] = append(adjacency[pre], course)
		indgree[course]++
	}

	queue := []int{}
	for i := 0; i < numCourses; i++ {
		if indgree[i] == 0 {
			queue = append(queue, i)
		}
	}

	cnt := 0
	for len(queue) > 0 {
		node := queue[0]
		queue = queue[1:]
		cnt++

		for _, nei := range adjacency[node] {
			indgree[nei]--
			if indgree[nei] == 0 {
				queue = append(queue, nei)
			}
		}
	}
	return cnt == numCourses
}

func canFinishDFS(numCourses int, prerequisites [][]int) bool {
	adjacency := make([][]int, numCourses)

	for _, p := range prerequisites {
		course, pre := p[0], p[1]
		adjacency[pre] = append(adjacency[pre], course)
	}

	state := make([]int, numCourses)
	var dfs func(int) bool
	dfs = func(node int) bool {
		if state[node] == 1 {
			return false
		}

		if state[node] == 2 {
			return true
		}

		state[node] = 1
		for _, nei := range adjacency[node] {
			if dfs(nei) == false {
				return false
			}
		}

		state[node] = 2
		return true
	}

	for i := 0; i < numCourses; i++ {
		if dfs(i) == false {
			return false
		}
	}
	return true
}
