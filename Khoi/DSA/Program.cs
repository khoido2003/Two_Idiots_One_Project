using DSA.Graph;
using DSA.LinkedList;
using DSA.PrefixSum;
using DSA.Sort;
using DSA.Tree;

int[] arr = { 5, 12, 13, 7, 14, 2, 17, 23, 27, 3, 8, 11 };

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

List<List<int>> adjList = new List<List<int>>
{
    new List<int> { 2 },
    new List<int> { 0 },
    //new List<int> { 0, 3 },
    new List<int> { },
    // new List<int> { 5 },
    //new List<int> { 1, 2 },
};

List<List<int>> adjList2 = new List<List<int>>
{
    new List<int> { 1 },
    new List<int> { 0, 2 },
    new List<int> { 1, 3 },
    new List<int> { 2 },
    //new List<int> { 1, 2 },
};

/*
List<int> res = GraphTheory.TopoSort(adjList);

foreach (var el in res)
{
    Console.Write(el + " ");
}
*/

//Console.WriteLine(GraphTheory.IsCyclic(adjList));
Console.WriteLine(GraphTheory.IsCycle(adjList2));
