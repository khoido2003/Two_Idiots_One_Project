using System.Text;
using DSA.Backtracking;
using DSA.DynamicProgramming;
using DSA.Graph;
using DSA.Greedy;
using DSA.LinkedList;
using DSA.PrefixSum;
using DSA.Sort;
using DSA.Tree;

/////////////////////////////////////////////////////////////////
int N = 5;
int[][] mat =
[
    [0, 1, 0, 1, 0],
    [1, 0, 1, 1, 1],
    [0, 1, 0, 0, 1],
    [1, 1, 0, 0, 1],
    [0, 1, 1, 1, 0],
];

var res = BacktrackingTheory.HamiltonianCycle(N, mat);

foreach (var el in res)
{
    Console.Write(el + " ");
}

/*
int V = 5;
int[][] edges =
[
    [0, 1],
    [0, 2],
    [0, 3],
    [1, 2],
    [1, 4],
    [2, 3],
    [2, 4],
    [3, 4],
];

int m = 3;

Console.WriteLine(BacktrackingTheory.MColoringProblem(V, edges, m));
*/

/*
int[] set = [3, 34, 4, 12, 5, 2];
int sum = 7;

var list = BacktrackingTheory.SubsetSumProblem(set, sum);

foreach (var el in list)
{
    foreach (var e in el)
    {
        Console.Write(e + " ");
    }

    Console.WriteLine();
}
*/

/*
string a = "send";
string b = "more";
string sum = "money";

Console.WriteLine(BacktrackingTheory.SolveCryptarithmetic(a, b, sum));
*/

/*
int n = 4;

var res = BacktrackingTheory.NthQueenProblem(n);

foreach (var el in res)
{
    foreach (var e in el)
    {
        Console.Write(e + " ");
    }
    Console.WriteLine();
}
*/

/*
int[][] matrix =
[
    [1, 0, 0, 0],
    [1, 1, 0, 1],
    [1, 1, 0, 0],
    [0, 1, 1, 1],
];

var res = BacktrackingTheory.RatInMaze(matrix);
foreach (var el in res)
{
    Console.Write(el + " ");
}
*/

/*
int n = 5;
int[][] res = BacktrackingTheory.KnightTour(n);

for (int i = 0; i < res.Length; i++)
{
    for (int j = 0; j < res[i].Length; j++)
    {
        Console.Write(res[i][j] + " ");
    }
    Console.WriteLine();
}
*/

/*
string s = "ABC";
List<string> res = BacktrackingTheory.CharPermutation(s);
foreach (var el in res)
{
    Console.Write(el + "  ");
}
*/

/*
int n = 6;
int[] dp = new int[n + 1];
Array.Fill(dp, -1);


Console.WriteLine(DynamicProgrammingTheory.MinSquares(n, dp));
*/

/*
int[][] tri =
[
    [2],
    [3, 9],
    [1, 6, 7],
];

int[] memo = new int[10000];

for (int i = 0; i < 10000; i++)
{
    memo[i] = -1;
}

Console.WriteLine(DynamicProgrammingTheory.MinimumSumPathInTriangle(tri, 0, 0, memo));

*/
/*
int n = 6;

Console.WriteLine(DynamicProgrammingTheory.CountValidParentheses(n));
*/

/*
int n = 6;
Console.WriteLine(DynamicProgrammingTheory.CalcNthCatalanNumber(n));
*/

/*
int n = 11;
int x = 2,
    y = 3,
    z = 5;

int[] dp = new int[n + 1];
for (var i = 0; i <= n; i++)
    dp[i] = -1;

Console.WriteLine(DynamicProgrammingTheory.MaximizeNumberOfSegmments(n, x, y, z, dp));
*/

/*
int[] cost = { 16, 19, 10, 12, 18 };
Console.WriteLine(DynamicProgrammingTheory.CostToReachTheTop(cost, 5));
*/

/*
int n = 10;

List<int> dp = new List<int>();
for (var i = 0; i <= n; i++)
    dp.Add(-1);

Console.WriteLine(DynamicProgrammingTheory.Tribonacci(n, dp));
*/

/*
int[] val = { 1, 2, 3 };
int[] wt = { 4, 5, 1 };
int W = 4;

int res = DynamicProgrammingTheory.Knapsack(W, val, wt);

Console.WriteLine(res);
*/

/*
int[] mices = { 4, -4, 2 };
int[] holes = { 4, 0, 5 };

// The required answer is returned
// from the function
int minTime = GreedyTheory.AssignMousesToHoles(mices, holes);
Console.WriteLine(minTime);
*/

/*
int wall = 24,
    m = 3,
    n = 5;
var (big, small, remain) = GreedyTheory.FittingShelves(wall, m, n);

Console.WriteLine("Big: " + big + " Small: " + small + " Empty: " + remain);
var result = GreedyTheory.FittingShelves(24, 3, 5);
Console.WriteLine(result);
*/

/*
int k = 1;
char[] arr = { 'P', 'T', 'T', 'P', 'T' };
Console.WriteLine(GreedyTheory.PoliceCatchThieves(arr, k));
*/

/*
int nr = 6,
    dr = 14;
Console.Write("Egyptian Fraction Representation of " + nr + "/" + dr + " is\n ");
GreedyTheory.PrintEgyptian(nr, dr);
*/

/*
void print2dArray(List<List<int>> arr)
{
    Console.Write("[");
    for (int i = 0; i < arr.Count; i++)
    {
        Console.Write("[{0}]", string.Join(", ", arr[i]));
        if (i != arr.Count - 1)
        {
            Console.Write(", ");
        }
    }
    Console.WriteLine("]");
}

int n = 9,
    p = 6;
int[] a = [7, 5, 4, 2, 9, 3];
int[] b = [4, 9, 6, 8, 7, 1];
int[] d = [98, 72, 10, 22, 17, 66];

List<List<int>> ans = GreedyTheory.FindWaterDistribution(n, p, a, b, d);

print2dArray(ans);
*/

/*
string s = "abcdefg";
int[] freq = { 5, 9, 12, 13, 16, 45, 6 };
GreedyTheory.Node root;
List<string> ans = GreedyTheory.HuffmanCode(s, freq, out root);

for (int i = 0; i < ans.Count; i++)
{
    Console.Write(ans[i] + " ");
}
Console.WriteLine();

Dictionary<char, string> map = new();
GreedyTheory.BuildMap(root, "", map);

string text = "face";
StringBuilder encoded = new();

foreach (char c in text)
{
    encoded.Append(map[c]);
}

Console.WriteLine("Encoded: " + encoded.ToString());
Console.WriteLine("Decoded: " + GreedyTheory.DecodeHuffman(root, encoded.ToString()));
*/

/*
int[] deadline = { 2, 1, 2, 1, 1 };
int[] profit = { 100, 19, 27, 25, 15 };
List<int> ans = GreedyTheory.JobSequencing(deadline, profit);
Console.WriteLine(ans[0] + " " + ans[1]);
*/

/*
int[] s1 = { 3, 2, 1, 1, 1 };
int[] s2 = { 4, 3, 2 };
int[] s3 = { 1, 1, 4, 1 };

Console.WriteLine(GreedyTheory.MaxEqualSumOfThreeStack(s1, s2, s3));
*/

/*
int k = 800;

var res = GreedyTheory.FindMinNumOfCurrencyNotes(k);

foreach (var el in res)
{
    Console.WriteLine(el.Key + " " + el.Value);
}
*/

/*
int[] prices = { 3, 2, 1, 4 };
int k = 2;
List<int> res = GreedyTheory.MinMaxCandy(prices, k);
Console.WriteLine(res[0] + " " + res[1]);
*/
/*
int[] price = { 10, 7, 19 };
int K = 45;

// int []price = { 7, 10, 4 };
// int K = 100;
Console.WriteLine(GreedyTheory.MaxStocks(price, K));
*/

/*
int[] arr = { 3, 1, 7, 1 };
int n = arr.Length;

Console.WriteLine(GreedyTheory.MinElements(arr, n));
*/

/*
int input = 28756;
int unlock_code = 98234;
Console.Write("Minimum Rotation = " + GreedyTheory.MinRotation(input, unlock_code));
*/
/*
int[] val = { 60, 100, 120 };
int[] wt = { 10, 20, 30 };
int capacity = 50;

double res = GreedyTheory.FractionalKnapsack(val, wt, capacity);
Console.WriteLine(res);
*/

////////////////////////////////////////////////////////////

// int[] arr = { 5, 12, 13, 7, 14, 2, 17, 23, 27, 3, 8, 11 };

// LinkedList.Node root = LinkedList.CreateFromArray(arr);
// LinkedList.PrintList(root);

// SortTheory.BurbleSort(arr);
// SortTheory.MergeSort(arr, 0, arr.Length - 1);

// SortTheory.QuickSort(arr, 0, arr.Length - 1);

// SortTheory.HeapSort(arr);

// var list = PrefixSumTheory.PrefSum(arr);

/*
foreach (var el in list)
{
    Console.Write(el + " ");
}

Console.WriteLine();

for (int i = 0; i <= arr.Length - 1; i++)
{
    Console.Write(arr[i] + " ");
}
*/

/////////////////////////////////////////////////////////

// BinaryNode root = TreeTheory.BuildBinaryTree(arr);

//TreeTheory.InsertNode(root, 19);

// TreeTheory.PrintTreeLevelOrder(root);

//TreeTheory.DeleteNode(root, 12);
//TreeTheory.PrintTreeLevelOrder(root);

//Console.WriteLine();

// BinaryNode bstRoot = TreeTheory.BuildBSTTree(arr);
// TreeTheory.PrintTreeLevelOrder(bstRoot);

// Console.WriteLine(TreeTheory.SearchBstTree(bstRoot, 24));

// Console.WriteLine(TreeTheory.FindTreeHeight(root));
// Console.WriteLine(TreeTheory.GetLevelOfNode(root, 8));
// Console.WriteLine(TreeTheory.GetParentOfNode(root, 8));

//////////////////////////////////////////////////////////
/*
List<List<int>> adjList = new List<List<int>>
{
    new List<int> { 2, 3 },
    new List<int> { 2 },
    new List<int> { 0, 1 },
    new List<int> { 0 },
    new List<int> { 5 },
    new List<int> { 4 },
};

List<int> route = GraphTheory.DFS(adjList);

foreach (var el in route)
{
    Console.Write(el + " ");
}
*/

/*
int[][] mat =
[
    [2, 1, 0, 2, 1],
    [1, 0, 1, 2, 1],
    [1, 0, 0, 2, 1],
];

int cnt = GraphPractice.RottenOrange(mat);
Console.WriteLine(cnt);
*/
/*
List<List<int>> adjList = new List<List<int>>
{
    new List<int> { 2 },
    new List<int> { 0 },
    //new List<int> { 0, 3 },
    new List<int> { },
    // new List<int> { 5 },
    //new List<int> { 1, 2 },
};
*/
/*
List<List<int>> adjList2 = new List<List<int>>
{
    new List<int> { 1 },
    new List<int> { 0, 2 },
    new List<int> { 1, 3 },
    new List<int> { 2 },
    //new List<int> { 1, 2 },
};
*/
/*
List<int> res = GraphTheory.TopoSort(adjList);

foreach (var el in res)
{
    Console.Write(el + " ");
}
*/

//Console.WriteLine(GraphTheory.IsCyclic(adjList));
//Console.WriteLine(GraphTheory.IsCycle(adjList2));
//

/*
List<List<(int, int)>> adjList =
[
    new() { (1, 4), (2, 8) },
    new() { (0, 4), (4, 6), (2, 3) },
    new() { (0, 8), (3, 2), (1, 3) },
    new() { (2, 2), (4, 10) },
    new() { (1, 6), (3, 10) },
];

List<int> res = GraphTheory.Dijstrak(adjList);
foreach (var el in res)
{
    Console.Write(el + " ");
}
*/

/*
(int, int, int)[] edges = [(1, 3, 2), (4, 3, -1), (2, 4, 1), (1, 2, 1), (0, 1, 5)];
int[] res = GraphTheory.BellmanFord(5, edges, 0);

for (int i = 0; i < res.Length; i++)
{
    Console.Write(res[i] + " ");
}
*/
/*
const int INF = 100000000;
int[,] dist =
{
    { 0, 4, INF, 5, INF },
    { INF, 0, 1, INF, 6 },
    { 2, INF, 0, 3, INF },
    { INF, INF, 1, 0, 2 },
    { 1, INF, INF, 4, 0 },
};

GraphTheory.Floyd(dist);

for (int i = 0; i < dist.GetLength(0); i++)
{
    for (int j = 0; j < dist.GetLength(1); j++)
    {
        Console.Write(dist[i, j] + " ");
    }
    Console.WriteLine();
}

*/

/*
int[][] edges =
{
    new int[] { 0, 1, 10 },
    new int[] { 1, 3, 15 },
    new int[] { 2, 3, 4 },
    new int[] { 2, 0, 6 },
    new int[] { 0, 3, 5 },
};

List<int> res = new();

int cost = GraphTheory.KruskalMst(4, edges, out res);

Console.WriteLine(cost);
foreach (var el in res)
{
    Console.Write(el + " ");
}
*/

/*
int[][] edges =
[
    [0, 1],
    [1, 4],
    [2, 3],
    [2, 4],
    [3, 4],
];

List<int> res = GraphTheory.FindArticulationPointsTarzan(5, edges);

foreach (var el in res)
{
    Console.Write(el + " ");
}

*/

/*
List<List<int>> adjList =
[
    new() { 1 },
    new() { 2 },
    new() { 0, 3 },
    new() { 4 },
    new() { 3, 5 },
    new() { },
];

var sccs = GraphTheory.FindSCCs(adjList);

foreach (var scc in sccs)
{
    foreach (int x in scc)
    {
        Console.Write(x + " ");
    }
    Console.WriteLine();
}
*/
