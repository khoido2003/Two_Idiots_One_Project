namespace DSA.Graph
{
    public class GraphPractice
    {
        // https://leetcode.com/problems/is-graph-bipartite/?envType=problem-list-v2&envId=graph

        public bool IsBipartite(int[][] graph)
        {
            List<List<int>> adjsList = new();

            for (int i = 0; i < graph.Length; i++)
            {
                adjsList.Add([]);

                for (int j = 0; j < graph[i].Length; j++)
                {
                    adjsList[i].Add(graph[i][j]);
                }
            }

            int[] color = new int[graph.Length];
            bool[] visited = new bool[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                if (visited[i])
                {
                    continue;
                }
                color[i] = 1;

                Queue<(int, int)> queue = new();

                queue.Enqueue((i, color[i]));
                visited[i] = true;

                while (queue.Count > 0)
                {
                    (int curNode, int curColor) = queue.Dequeue();

                    foreach (var el in adjsList[curNode])
                    {
                        if (!visited[el])
                        {
                            if (color[curNode] == 1)
                            {
                                color[el] = 2;
                            }
                            else
                            {
                                color[el] = 1;
                            }

                            visited[el] = true;
                            queue.Enqueue((el, color[el]));
                        }
                        else
                        {
                            if (color[el] == color[curNode])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        //////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/number-of-provinces/submissions/1959022700/?envType=problem-list-v2&envId=graph
        private void Bfs(List<List<int>> adjsList, bool[] visited, int curNode)
        {
            Queue<int> queue = new();

            queue.Enqueue(curNode);
            visited[curNode] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                foreach (var neighbor in adjsList[node])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        public int FindCircleNum(int[][] isConnected)
        {
            List<List<int>> adjsList = new();

            for (int i = 0; i < isConnected.Length; i++)
            {
                adjsList.Add([]);

                for (int j = 0; j < isConnected[i].Length; j++)
                {
                    if (isConnected[i][j] == 1 && i != j)
                    {
                        adjsList[i].Add(j);
                    }
                }
            }

            bool[] visited = new bool[isConnected.Length];
            int cnt = 0;

            for (int i = 0; i < isConnected.Length; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                Bfs(adjsList, visited, i);
                cnt++;
            }

            return cnt;
        }

        /////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/evaluate-division/submissions/1959003537/?envType=problem-list-v2&envId=graph

        private double Dijstrak(
            int n,
            string startNode,
            string endNode,
            Dictionary<string, List<(string, double)>> adjsList
        )
        {
            PriorityQueue<(string, double), double> pq = new();

            Dictionary<string, bool> visited = new();
            Dictionary<string, double> cost = new();

            foreach (var key in adjsList.Keys)
            {
                visited[key] = false;
                cost[key] = int.MaxValue;
            }

            pq.Enqueue((startNode, 1.0), 1.0);

            while (pq.Count > 0)
            {
                (string curNode, double curCost) = pq.Dequeue();

                if (curNode == endNode)
                {
                    return curCost;
                }

                if (visited[curNode])
                {
                    continue;
                }

                visited[curNode] = true;
                cost[curNode] = curCost;

                foreach (var (neighbor, costToNeighbor) in adjsList[curNode])
                {
                    if (!visited[neighbor])
                    {
                        double newCost = curCost * costToNeighbor;

                        pq.Enqueue((neighbor, newCost), newCost);
                        cost[neighbor] = newCost;
                    }
                }
            }
            return -1;
        }

        public double[] CalcEquation(
            IList<IList<string>> equations,
            double[] values,
            IList<IList<string>> queries
        )
        {
            Dictionary<string, List<(string, double)>> adjsList = new();

            for (int i = 0; i < equations.Count; i++)
            {
                string startNode = equations[i][0];
                string endNode = equations[i][1];

                double value = values[i];

                if (!adjsList.ContainsKey(startNode))
                {
                    adjsList[startNode] = [];
                }

                if (!adjsList.ContainsKey(endNode))
                {
                    adjsList[endNode] = [];
                }

                adjsList[startNode].Add((endNode, value));
                adjsList[endNode].Add((startNode, 1 / value));
            }

            int n = adjsList.Count;

            List<double> res = new();

            for (int i = 0; i < queries.Count; i++)
            {
                string firstNode = queries[i][0];
                string secondNode = queries[i][1];

                if (!adjsList.ContainsKey(firstNode) || !adjsList.ContainsKey(secondNode))
                {
                    res.Add(-1);
                }
                else if (firstNode == secondNode)
                {
                    res.Add(1.0);
                    continue;
                }
                else
                {
                    double cost = Dijstrak(n, firstNode, secondNode, adjsList);

                    res.Add(cost);
                }
            }
            return res.ToArray();
        }

        ////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/minimum-height-trees/?envType=problem-list-v2&envId=graph

        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if (n == 1)
                return new List<int> { 0 };

            List<List<int>> adjsList = new();

            for (int i = 0; i < n; i++)
            {
                adjsList.Add([]);
            }

            int[] topo = new int[n];

            for (int i = 0; i < edges.Length; i++)
            {
                int firstNode = edges[i][0];
                int secondNode = edges[i][1];

                adjsList[firstNode].Add(secondNode);
                adjsList[secondNode].Add(firstNode);

                topo[firstNode]++;
                topo[secondNode]++;
            }

            int totalNode = n;
            Queue<int> queue = new();

            for (int i = 0; i < topo.Length; i++)
            {
                if (topo[i] == 1)
                {
                    queue.Enqueue(i);
                }
            }

            while (totalNode > 2)
            {
                int leafNodeAmount = queue.Count;
                totalNode -= leafNodeAmount;

                for (int i = 0; i < leafNodeAmount; i++)
                {
                    int leafNode = queue.Dequeue();
                    topo[leafNode]--;

                    foreach (var neighbor in adjsList[leafNode])
                    {
                        topo[neighbor]--;

                        if (topo[neighbor] == 1)
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            List<int> res = new();

            while (queue.Count > 0)
            {
                res.Add(queue.Dequeue());
            }

            return [.. res];
        }

        public IList<int> FindMinHeightTreesSlow(int n, int[][] edges)
        {
            List<List<int>> adjsList = new();

            for (int i = 0; i < n; i++)
            {
                adjsList.Add([]);
            }

            for (int i = 0; i < edges.Length; i++)
            {
                int firstNode = edges[i][0];
                int secondNode = edges[i][1];

                adjsList[firstNode].Add(secondNode);
                adjsList[secondNode].Add(firstNode);
            }

            List<int> res = new();
            Dictionary<int, int> map = new();

            int minHeight = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                Queue<int> queue = new();
                bool[] visited = new bool[n];

                int cnt = 0;

                queue.Enqueue(i);
                visited[i] = true;

                while (queue.Count > 0)
                {
                    int size = queue.Count;
                    for (int j = 0; j < size; j++)
                    {
                        int curNode = queue.Dequeue();

                        foreach (var neighbor in adjsList[curNode])
                        {
                            if (!visited[neighbor])
                            {
                                queue.Enqueue(neighbor);
                                visited[neighbor] = true;
                            }
                        }
                    }
                    cnt++;
                }

                minHeight = Math.Min(cnt - 1, minHeight);

                map[i] = cnt - 1;
            }

            foreach (var (key, value) in map)
            {
                if (value == minHeight)
                {
                    res.Add(key);
                }
            }

            return res.ToArray();
        }

        ////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/course-schedule-ii/submissions/1958728565/?envType=problem-list-v2&envId=graph

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            List<List<int>> adjsList = new();

            for (int i = 0; i < numCourses; i++)
            {
                adjsList.Add([]);
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                int courseTaken = prerequisites[i][0];
                int courseDepend = prerequisites[i][1];

                adjsList[courseDepend].Add(courseTaken);
            }

            int[] topo = new int[numCourses];

            for (int i = 0; i < adjsList.Count; i++)
            {
                for (int j = 0; j < adjsList[i].Count; j++)
                {
                    topo[adjsList[i][j]]++;
                }
            }

            Queue<int> queue = new();
            int[] parent = new int[numCourses];

            List<int> res = new();

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }

            int cnt = 0;

            int firstNode = -1;

            for (int i = 0; i < topo.Length; i++)
            {
                if (topo[i] == 0)
                {
                    queue.Enqueue(i);
                    firstNode = i;
                    parent[i] = i;
                }
            }

            while (queue.Count > 0)
            {
                int curNode = queue.Dequeue();
                res.Add(curNode);

                cnt++;

                foreach (var neighbor in adjsList[curNode])
                {
                    topo[neighbor]--;

                    if (topo[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                        parent[neighbor] = curNode;
                    }
                }
            }

            if (cnt != numCourses)
            {
                return [];
            }

            return res.ToArray();
        }

        /////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/course-schedule/submissions/1958706990/?envType=problem-list-v2&envId=graph

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            List<List<int>> adjsList = new();

            for (int i = 0; i < numCourses; i++)
            {
                adjsList.Add([]);
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                int courseTaken = prerequisites[i][0];
                int courseDepend = prerequisites[i][1];

                adjsList[courseDepend].Add(courseTaken);
            }

            int[] topo = new int[numCourses];

            for (int i = 0; i < adjsList.Count; i++)
            {
                for (int j = 0; j < adjsList[i].Count; j++)
                {
                    topo[adjsList[i][j]]++;
                }
            }

            Queue<int> queue = new();
            bool[] visited = new bool[numCourses];

            int cnt = 0;

            for (int i = 0; i < topo.Length; i++)
            {
                if (topo[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                int curNode = queue.Dequeue();

                visited[curNode] = true;
                cnt++;

                foreach (var neighbor in adjsList[curNode])
                {
                    if (visited[neighbor])
                    {
                        continue;
                    }

                    topo[neighbor]--;

                    if (topo[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return cnt == numCourses;
        }

        ////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/clone-graph/?envType=problem-list-v2&envId=graph

        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        public Node CloneGraph(Node node)
        {
            if (node == null)
            {
                return null;
            }

            Queue<Node> queue = new();
            Dictionary<Node, Node> clonedMap = new();

            Node cloneNode = new Node(node.val);
            clonedMap[node] = cloneNode;

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Node curNode = queue.Dequeue();

                foreach (Node neighbor in curNode.neighbors)
                {
                    if (!clonedMap.ContainsKey(neighbor))
                    {
                        Node newCloneNeighbor = new Node(neighbor.val);
                        clonedMap[neighbor] = newCloneNeighbor;
                        queue.Enqueue(neighbor);

                        clonedMap[curNode].neighbors.Add(newCloneNeighbor);
                    }
                    else
                    {
                        clonedMap[curNode].neighbors.Add(clonedMap[neighbor]);
                    }
                }
            }

            return cloneNode;
        }

        /////////////////////////////////////////////////////////////////////

        public static int RottenOrange(int[][] mat)
        {
            Queue<(int, int)> queue = new();
            (int, int)[] directions = [(0, -1), (-1, 0), (0, 1), (1, 0)];

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                    }
                }
            }

            bool flag = false;
            int cnt = 0;

            while (queue.Count > 0)
            {
                int len = queue.Count;

                flag = false;

                for (int i = 0; i < len; i++)
                {
                    var curNode = queue.Dequeue();

                    foreach (var el in directions)
                    {
                        (int, int) neighbor = (curNode.Item1 + el.Item1, curNode.Item2 + el.Item2);

                        int neighborX = neighbor.Item1;
                        int neighborY = neighbor.Item2;

                        if (
                            neighborX >= 0
                            && neighborY >= 0
                            && neighborX < mat.Length
                            && neighborY < mat[0].Length
                            && mat[neighborX][neighborY] == 1
                        )
                        {
                            queue.Enqueue((neighborX, neighborY));
                            mat[neighborX][neighborY] = 2;
                            flag = true;
                        }
                    }
                }

                if (flag)
                {
                    cnt++;
                }
            }

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 1)
                    {
                        return -1;
                    }
                }
            }

            return cnt;
        }
    }
}
