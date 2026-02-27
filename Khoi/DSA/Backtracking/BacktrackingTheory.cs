namespace DSA.Backtracking
{
    public class BacktrackingTheory
    {
        public static int[] HamiltonianCycle(int N, int[][] adjMat)
        {
            bool[] visited = new bool[N];
            int[] path = new int[N];

            List<List<int>> adjsList = new();

            for (int i = 0; i < N; i++)
            {
                adjsList.Add([]);
            }

            for (int i = 0; i < adjMat.Length; i++)
            {
                for (int j = 0; j < adjMat.Length; j++)
                {
                    if (adjMat[i][j] != 0)
                    {
                        adjsList[i].Add(j);
                    }
                }
            }

            visited[0] = true;
            path[0] = 0;

            BacktrackHamiltonianCycle(N, adjsList, visited, path, 1);

            return path;
        }

        private static bool BacktrackHamiltonianCycle(
            int N,
            List<List<int>> adjsList,
            bool[] visited,
            int[] path,
            int currentPos
        )
        {
            if (currentPos == adjsList.Count)
            {
                return adjsList[path[currentPos - 1]].Contains(0);
            }

            for (int v = 1; v < N; v++)
            {
                int prevNode = path[currentPos - 1];
                if (!visited[v] && adjsList[prevNode].Contains(v))
                {
                    visited[v] = true;
                    path[currentPos] = v;

                    if (BacktrackHamiltonianCycle(N, adjsList, visited, path, currentPos + 1))
                    {
                        return true;
                    }

                    visited[v] = false;
                }
            }

            return false;
        }

        ///////////////////////////////////////////////////////////////

        public static bool MColoringProblem(int V, int[][] edges, int m)
        {
            List<List<int>> adjsList = new();

            for (int i = 0; i < V; i++)
            {
                adjsList.Add([]);
            }

            for (int i = 0; i < edges.Length; i++)
            {
                int startNode = edges[i][0];
                int endNode = edges[i][1];

                adjsList[startNode].Add(endNode);
                adjsList[endNode].Add(startNode);
            }

            int[] colors = new int[V];

            if (BacktrackMColoringProblem(V, adjsList, m, colors, 0))
            {
                return true;
            }
            return false;
        }

        private static bool BacktrackMColoringProblem(
            int V,
            List<List<int>> adjsList,
            int m,
            int[] colors,
            int currentVertex
        )
        {
            if (currentVertex == V)
            {
                return true;
            }

            bool isSafe = true;

            for (int i = 0; i < m; i++)
            {
                foreach (int neighbor in adjsList[currentVertex])
                {
                    if (colors[neighbor] == i)
                    {
                        isSafe = false;
                        break;
                    }
                }

                if (isSafe)
                {
                    colors[currentVertex] = i;

                    if (BacktrackMColoringProblem(V, adjsList, m, colors, currentVertex + 1))
                    {
                        return true;
                    }

                    colors[currentVertex] = -1;
                }
            }

            return false;
        }

        ///////////////////////////////////////////////////////////////////

        public static List<int[]> SubsetSumProblem(int[] arr, int sum)
        {
            List<int[]> res = new();
            List<int> uniqueList = arr.ToList();

            List<int> currentGroup = new();

            BacktrackSubsetSum(sum, res, uniqueList, 0, currentGroup, 0);

            return res;
        }

        private static void BacktrackSubsetSum(
            int sum,
            List<int[]> res,
            List<int> uniqueList,
            int currentSum,
            List<int> currentGroup,
            int currentIndex
        )
        {
            if (currentSum == sum)
            {
                int[] group = currentGroup.ToArray();

                res.Add(group);

                return;
            }

            if (currentIndex >= uniqueList.Count || currentSum > sum)
            {
                return;
            }

            // Take
            currentSum += uniqueList[currentIndex];
            currentGroup.Add(uniqueList[currentIndex]);

            BacktrackSubsetSum(sum, res, uniqueList, currentSum, currentGroup, currentIndex + 1);

            // Drop
            currentSum -= uniqueList[currentIndex];
            currentGroup.RemoveAt(currentGroup.Count - 1);

            BacktrackSubsetSum(sum, res, uniqueList, currentSum, currentGroup, currentIndex + 1);
        }

        ///////////////////////////////////////////////////////////////////////////

        public static string SolveCryptarithmetic(string a, string b, string sum)
        {
            bool[] used = new bool[10];
            Dictionary<char, int> map = new();

            HashSet<char> set = [.. a.ToCharArray(), .. b.ToCharArray(), .. sum.ToCharArray()];

            List<char> uniqueChars = set.ToList();

            string res = "";

            bool check = BacktrackSolveCryptarithmetic(
                a,
                b,
                sum,
                uniqueChars,
                used,
                map,
                0,
                ref res
            );

            if (check)
            {
                return res;
            }
            else
            {
                return "-1";
            }
        }

        private static bool BacktrackSolveCryptarithmetic(
            string a,
            string b,
            string sum,
            List<char> uniqueChars,
            bool[] used,
            Dictionary<char, int> map,
            int currentIndex,
            ref string res
        )
        {
            if (currentIndex == uniqueChars.Count)
            {
                string stringA = "";
                foreach (char c in a.ToCharArray())
                {
                    stringA += map[c].ToString();
                }

                int numA = int.Parse(stringA);

                string stringB = "";
                foreach (char c in b.ToCharArray())
                {
                    stringB += map[c].ToString();
                }

                int numB = int.Parse(stringB);

                string stringSum = "";
                foreach (char c in sum.ToCharArray())
                {
                    stringSum += map[c].ToString();
                }

                int numSum = int.Parse(stringSum);

                if (numA + numB == numSum)
                {
                    res += stringA + " " + stringB + " " + stringSum;
                    return true;
                }

                return false;
            }

            for (int i = 0; i <= 9; i++)
            {
                if (used[i])
                {
                    continue;
                }
                map[uniqueChars[currentIndex]] = i;
                used[i] = true;

                if (
                    BacktrackSolveCryptarithmetic(
                        a,
                        b,
                        sum,
                        uniqueChars,
                        used,
                        map,
                        currentIndex + 1,
                        ref res
                    )
                )
                {
                    return true;
                }

                map[uniqueChars[currentIndex]] = -1;
                used[i] = false;
            }

            return false;
        }

        /////////////////////////////////////////////////////////////////////

        public static List<List<int>> NthQueenProblem(int n)
        {
            int[] queenPlacement = new int[n];
            List<List<int>> res = new();
            List<int> curCase = [];

            for (int i = 0; i < n; i++)
            {
                curCase.Add(-1);
            }

            BacktrackNthQueenProblem(n, queenPlacement, res, 0, curCase);

            return res;
        }

        private static void BacktrackNthQueenProblem(
            int n,
            int[] queenPlacement,
            List<List<int>> res,
            int curRow,
            List<int> curCase
        )
        {
            if (curRow == n)
            {
                res.Add(new List<int>(curCase));
                return;
            }

            for (int col = 0; col < n; col++)
            {
                bool isSafe = true;

                for (int prevRow = 0; prevRow < curRow; prevRow++)
                {
                    // Check column
                    if (queenPlacement[prevRow] == col)
                    {
                        isSafe = false;
                        break;
                    }
                    // Check diagonal
                    if (Math.Abs(prevRow - curRow) == Math.Abs(queenPlacement[prevRow] - col))
                    {
                        isSafe = false;
                        break;
                    }
                }

                if (isSafe)
                {
                    queenPlacement[curRow] = col;
                    curCase[curRow] = col + 1;

                    BacktrackNthQueenProblem(n, queenPlacement, res, curRow + 1, curCase);

                    queenPlacement[curRow] = -1;
                    curCase[curRow] = -1;
                }
            }
        }

        //////////////////////////////////////////////////////////////

        public static List<string> RatInMaze(int[][] matrix)
        {
            bool[][] visited = new bool[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                visited[i] = new bool[matrix[i].Length];
            }

            List<string> res = new();

            BacktrackRatInMaze(matrix, visited, res, 0, 0, "");

            return res;
        }

        private static void BacktrackRatInMaze(
            int[][] matrix,
            bool[][] visited,
            List<string> res,
            int curX,
            int curY,
            string currentDirection
        )
        {
            if (curX == matrix.Length - 1 && curY == matrix.Length - 1)
            {
                res.Add(currentDirection);
                return;
            }

            if (curX < 0 || curX >= matrix.Length || curY < 0 || curY >= matrix.Length)
            {
                return;
            }

            if (matrix[curX][curY] == 0)
            {
                return;
            }

            if (visited[curX][curY])
            {
                return;
            }

            int[] directionX = [-1, 0, 1, 0];
            int[] directionY = [0, 1, 0, -1];
            string[] direction = ["U", "R", "D", "L"];

            visited[curX][curY] = true;

            for (int i = 0; i < 4; i++)
            {
                currentDirection += direction[i];

                BacktrackRatInMaze(
                    matrix,
                    visited,
                    res,
                    curX + directionX[i],
                    curY + directionY[i],
                    currentDirection
                );

                currentDirection = currentDirection.Substring(0, currentDirection.Length - 1);
            }

            visited[curX][curY] = false;
        }

        ///////////////////////////////////////////////////////////////

        public static int[][] KnightTour(int n)
        {
            bool[][] visited = new bool[n][];
            int[][] res = new int[n][];

            for (int i = 0; i < n; i++)
            {
                visited[i] = new bool[n];
                res[i] = new int[n];
            }

            bool check = BacktrackKnightTour(n, visited, res, 0, 0, 0);

            if (check == true)
            {
                return res;
            }
            else
                return
                [
                    [-1],
                ];
        }

        private static bool BacktrackKnightTour(
            int n,
            bool[][] visited,
            int[][] res,
            int currentStep,
            int row,
            int col
        )
        {
            if (row < 0 || row >= n || col < 0 || col >= n)
            {
                return false;
            }

            if (visited[row][col])
            {
                return false;
            }

            if (currentStep == n * n - 1)
            {
                return true;
            }

            int[] dr = { 2, 2, -2, -2, 1, 1, -1, -1 };
            int[] dc = { 1, -1, 1, -1, 2, -2, 2, -2 };

            visited[row][col] = true;
            res[row][col] = currentStep;

            for (int i = 0; i < 8; i++)
            {
                if (row + dr[i] < 0 || row + dr[i] >= n || col + dc[i] < 0 || col + dc[i] >= n)
                {
                    continue;
                }

                if (BacktrackKnightTour(n, visited, res, currentStep + 1, row + dr[i], col + dc[i]))
                {
                    return true;
                }
            }
            visited[row][col] = false;

            return false;
        }

        ////////////////////////////////////////////////////////////////////////////

        public static List<string> CharPermutation(string s)
        {
            List<string> res = new();
            char[] chars = s.ToCharArray();
            bool[] used = new bool[1000];

            BacktrackCharPermutation(chars, used, "", res);

            return res;
        }

        private static void BacktrackCharPermutation(
            char[] chars,
            bool[] used,
            string current,
            List<string> res
        )
        {
            if (current.Length == chars.Length)
            {
                res.Add(current);
            }

            for (int i = 0; i < chars.Length; i++)
            {
                if (used[i])
                {
                    continue;
                }

                used[i] = true;

                BacktrackCharPermutation(chars, used, current + chars[i], res);

                used[i] = false;
            }
        }
    }
}
