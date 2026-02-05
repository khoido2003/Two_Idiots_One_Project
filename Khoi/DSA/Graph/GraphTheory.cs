namespace DSA.Graph
{
    public class GraphTheory
    {
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
