namespace DSA.Graph
{
    public class GraphTheory
    {
        // Strongly connected graph (Tarjan)

        public static List<List<int>> FindSCCs(List<List<int>> adjList)
        {
            int[] discovery = new int[adjList.Count];
            int[] low = new int[adjList.Count];
            bool[] onStack = new bool[adjList.Count];
            Stack<int> stack = new();

            List<List<int>> res = new();

            int time = 0;

            for (int i = 0; i < adjList.Count; i++)
            {
                discovery[i] = -1;
            }

            for (int i = 0; i < adjList.Count; i++)
            {
                if (discovery[i] == -1)
                {
                    DfsTarjanSCCs(i, ref time, discovery, low, onStack, stack, adjList, res);
                }
            }

            return res;
        }

        private static void DfsTarjanSCCs(
            int curNode,
            ref int time,
            int[] discovery,
            int[] low,
            bool[] onStack,
            Stack<int> stack,
            List<List<int>> adjList,
            List<List<int>> res
        )
        {
            discovery[curNode] = low[curNode] = time++;
            stack.Push(curNode);
            onStack[curNode] = true;

            foreach (var el in adjList[curNode])
            {
                if (discovery[el] == -1)
                {
                    DfsTarjanSCCs(el, ref time, discovery, low, onStack, stack, adjList, res);

                    low[curNode] = Math.Min(low[curNode], low[el]);
                }
                else if (onStack[el])
                {
                    low[curNode] = Math.Min(low[curNode], discovery[el]);
                }
            }

            if (low[curNode] == discovery[curNode])
            {
                List<int> scc = [];
                int node;
                do
                {
                    node = stack.Pop();
                    onStack[node] = false;
                    scc.Add(node);
                } while (node != curNode);

                res.Add(scc);
            }
        }

        ////////////////////////////////////////////////////////////////

        // Articulation point (Tarjan)

        public static List<int> FindArticulationPointsTarzan(int V, int[][] edges)
        {
            List<List<int>> adjList = EdgesToAdj(V, edges);
            int[] discovery = new int[V];
            int[] low = new int[V];
            bool[] visited = new bool[V];
            int[] parent = new int[V];
            bool[] isArt = new bool[V];

            List<int> res = new();

            int time = 0;

            for (int i = 0; i < V; i++)
            {
                parent[i] = -1;
            }

            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    DfsTaranArticulation(
                        i,
                        adjList,
                        ref time,
                        discovery,
                        low,
                        visited,
                        parent,
                        isArt
                    );
                }
            }

            for (int i = 0; i < V; i++)
            {
                if (isArt[i])
                {
                    res.Add(i);
                }
            }

            return res;
        }

        private static void DfsTaranArticulation(
            int curNode,
            List<List<int>> adjList,
            ref int time,
            int[] discovery,
            int[] low,
            bool[] visited,
            int[] parent,
            bool[] isArt
        )
        {
            int children = 0;
            visited[curNode] = true;
            discovery[curNode] = low[curNode] = time++;

            foreach (var el in adjList[curNode])
            {
                if (!visited[el])
                {
                    children++;
                    parent[el] = curNode;

                    DfsTaranArticulation(
                        el,
                        adjList,
                        ref time,
                        discovery,
                        low,
                        visited,
                        parent,
                        isArt
                    );

                    low[curNode] = Math.Min(low[curNode], low[el]);

                    if (parent[curNode] == -1 && children >= 2)
                    {
                        isArt[curNode] = true;
                    }

                    if (parent[curNode] != -1 && low[el] >= discovery[curNode])
                    {
                        isArt[curNode] = true;
                    }
                }
                else if (el != parent[curNode])
                {
                    low[curNode] = Math.Min(low[curNode], discovery[el]);
                }
            }
        }

        // ///////////////////////////////////////////////////////

        // Articulation point (DFS)

        private static void DfsArticulation(int i, List<List<int>> adjlist, bool[] visited)
        {
            visited[i] = true;

            for (int j = 0; j < adjlist[i].Count; j++)
            {
                int neighbor = adjlist[i][j];
                if (!visited[neighbor])
                {
                    DfsArticulation(neighbor, adjlist, visited);
                }
            }
        }

        private static List<List<int>> EdgesToAdj(int V, int[][] edges)
        {
            List<List<int>> adjList = new();

            for (int i = 0; i < V; i++)
            {
                adjList.Add(new List<int>());
            }

            for (int i = 0; i < edges.Length; i++)
            {
                int startNode = edges[i][0];
                int endNode = edges[i][1];

                adjList[startNode].Add(endNode);
                adjList[endNode].Add(startNode);
            }

            return adjList;
        }

        public static List<int> FindArticulationPoints(int V, int[][] edges)
        {
            List<List<int>> adjList = EdgesToAdj(V, edges);

            List<int> res = new();

            for (int i = 0; i < V; i++)
            {
                bool[] visited = new bool[V];

                visited[i] = true;

                int comp = 0;

                foreach (var neighbor in adjList[i])
                {
                    if (!visited[neighbor])
                    {
                        DfsArticulation(neighbor, adjList, visited);
                        comp++;
                    }

                    if (comp > 1)
                    {
                        res.Add(i);
                        break;
                    }
                }
            }

            return res;
        }

        /////////////////////////////////////////////////////////

        // Kruskal
        public static int KruskalMst(int V, int[][] edges, out List<int> nodeList)
        {
            Quicksort(edges, 0, edges.Length - 1);

            DisjointSet disjointSet = new(V);
            int totalCost = 0;
            int cnt = 0;

            bool[] visited = new bool[V];
            nodeList = new();

            foreach (var e in edges)
            {
                int startNode = e[0];
                int endNode = e[1];
                int cost = e[2];

                if (disjointSet.Find(startNode) != disjointSet.Find(endNode))
                {
                    disjointSet.Union(startNode, endNode);
                    totalCost += cost;
                    cnt++;

                    if (!visited[startNode])
                    {
                        nodeList.Add(startNode);
                        visited[startNode] = true;
                    }

                    if (!visited[endNode])
                    {
                        nodeList.Add(endNode);
                        visited[endNode] = true;
                    }

                    if (cnt == V - 1)
                    {
                        break;
                    }
                }
            }

            return totalCost;
        }

        private static int Patition(int[][] edges, int low, int high)
        {
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (edges[j][2] < edges[high][2])
                {
                    i++;
                    var tmp = edges[i];
                    edges[i] = edges[j];
                    edges[j] = tmp;
                }
            }

            var tmp2 = edges[high];
            edges[high] = edges[i + 1];
            edges[i + 1] = tmp2;

            return i + 1;
        }

        private static void Quicksort(int[][] edges, int low, int high)
        {
            if (low < high)
            {
                int p = Patition(edges, low, high);
                Quicksort(edges, low, p - 1);
                Quicksort(edges, p + 1, high);
            }
        }

        private class DisjointSet
        {
            private int[] parent;
            private int[] rank;

            public DisjointSet(int size)
            {
                parent = new int[size];
                rank = new int[size];
                for (int i = 0; i < size; i++)
                {
                    parent[i] = i;
                    rank[i] = 1;
                }
            }

            public int Find(int x)
            {
                if (parent[x] != x)
                {
                    parent[x] = Find(parent[x]);
                }
                return parent[x];
            }

            public bool Union(int a, int b)
            {
                int rootA = Find(a);
                int rootB = Find(b);

                if (rootA == rootB)
                {
                    return false;
                }

                if (rank[rootA] < rank[rootB])
                {
                    parent[rootA] = rootB;
                }
                else if (rank[rootA] > rank[rootB])
                {
                    parent[rootB] = rootA;
                }
                else
                {
                    parent[rootB] = rootA;
                    rank[rootA]++;
                }
                return true;
            }
        }

        //////////////////////////////////////////////////////////

        // Floyd
        public static void Floyd(int[,] dist)
        {
            int V = dist.GetLength(0);

            for (int k = 0; k < V; k++)
            {
                for (int i = i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (dist[i, k] != 1e8 && dist[k, j] != 1e8)
                        {
                            dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                        }
                    }
                }
            }
        }

        //////////////////////////////////////////////////////

        // Bellman-Ford
        public static int[] BellmanFord(int V, (int, int, int)[] edges, int root)
        {
            int[] res = new int[V];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = int.MaxValue;
            }

            res[root] = 0;

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < edges.Length; j++)
                {
                    int startNode = edges[j].Item1;
                    int endNode = edges[j].Item2;
                    int cost = edges[j].Item3;

                    if (res[startNode] != int.MaxValue && res[endNode] > res[startNode] + cost)
                    {
                        if (i == V - 1)
                        {
                            return new int[] { -1 };
                        }

                        res[endNode] = res[startNode] + cost;
                    }
                }
            }

            return res;
        }

        ///////////////////////////////////////////////////////

        // Dijstrak
        public static List<int> Dijstrak(List<List<(int, int)>> adj)
        {
            PriorityQueue<(int, int), int> pq = new();
            List<int> res = new();

            for (int i = 0; i < adj.Count; i++)
            {
                res.Add(int.MaxValue);
            }

            int root = 0,
                rootDistance = 0;

            res[0] = rootDistance;
            pq.Enqueue((root, rootDistance), rootDistance);

            bool[] visited = new bool[adj.Count];

            while (pq.Count > 0)
            {
                (int curNode, int curDistance) = pq.Dequeue();

                if (visited[curNode])
                {
                    continue;
                }

                visited[curNode] = true;
                res[curNode] = curDistance;

                foreach (var neighbor in adj[curNode])
                {
                    int newNeighborWeight = neighbor.Item2 + res[curNode];
                    int curNeighborWeight = res[neighbor.Item1];

                    if (newNeighborWeight < curNeighborWeight)
                    {
                        res[neighbor.Item1] = newNeighborWeight;
                        pq.Enqueue((neighbor.Item1, newNeighborWeight), newNeighborWeight);
                    }
                }
            }
            return res;
        }

        //////////////////////////////////////////////////////////

        // Detect cycle in undirected graph
        public static bool IsCycle(List<List<int>> adj)
        {
            Queue<(int, int)> queue = new();
            bool[] visited = new bool[adj.Count];
            queue.Enqueue((0, -1));

            while (queue.Count > 0)
            {
                var (curNode, parent) = queue.Dequeue();

                foreach (var el in adj[curNode])
                {
                    if (!visited[el])
                    {
                        queue.Enqueue((el, curNode));
                        visited[el] = true;
                    }
                    else if (el != parent)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        ///////////////////////////////////////////////////////

        // Detect cycle in directed graph
        public static bool IsCyclic(List<List<int>> adj)
        {
            int[] indegree = new int[adj.Count];

            for (int i = 0; i < indegree.Length; i++)
            {
                indegree[i] = 0;
            }

            for (int i = 0; i < adj.Count; i++)
            {
                for (int j = 0; j < adj[i].Count; j++)
                {
                    indegree[adj[i][j]]++;
                }
            }

            Queue<int> queue = new();
            int visited = 0;

            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                int curNode = queue.Dequeue();
                visited++;

                for (int i = 0; i < adj[curNode].Count; i++)
                {
                    int neighbor = adj[curNode][i];

                    indegree[neighbor]--;

                    if (indegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return visited != adj.Count;
        }

        //////////////////////////////////////////////////////

        // Kahn's algorithm
        public static List<int> TopoSort(List<List<int>> adj)
        {
            int[] indegree = new int[adj.Count];

            for (int i = 0; i < indegree.Length; i++)
            {
                indegree[i] = 0;
            }

            for (int i = 0; i < adj.Count; i++)
            {
                for (int j = 0; j < adj[i].Count; j++)
                {
                    indegree[adj[i][j]]++;
                }
            }

            Queue<int> queue = new();

            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            List<int> res = new();

            while (queue.Count > 0)
            {
                int curNode = queue.Dequeue();
                res.Add(curNode);

                foreach (var el in adj[curNode])
                {
                    indegree[el]--;

                    if (indegree[el] == 0)
                    {
                        queue.Enqueue(el);
                    }
                }
            }

            return res;
        }

        ////////////////////////////////////////////////////

        // BFS

        public static List<int> BFS(List<List<int>> adj)
        {
            Queue<int> queue = new();
            bool[] visited = new bool[1000];

            List<int> nodeList = new();

            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                int curNode = queue.Dequeue();

                if (!visited[curNode])
                {
                    nodeList.Add(curNode);
                }

                foreach (var neighbor in adj[curNode])
                {
                    if (!visited[neighbor])
                    {
                        queue.Enqueue(neighbor);
                        visited[curNode] = true;
                    }
                }
            }

            return nodeList;
        }

        /////////////////////////////////////////////////////////

        // DFS

        public static List<int> DFS(List<List<int>> adj)
        {
            bool[] visited = new bool[adj.Count];
            List<int> res = new();
            DfsRec(adj, visited, 0, res);

            return res;
        }

        private static void DfsRec(List<List<int>> adj, bool[] visited, int node, List<int> res)
        {
            visited[node] = true;
            res.Add(node);

            foreach (var neighbor in adj[node])
            {
                if (!visited[neighbor])
                {
                    DfsRec(adj, visited, neighbor, res);
                }
            }
        }
    }
}
