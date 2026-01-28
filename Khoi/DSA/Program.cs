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

BinaryNode root = TreeTheory.BuildTree(arr);

TreeTheory.PrintTreeLevelOrder(root);
Console.WriteLine(TreeTheory.FindTreeHeight(root));
