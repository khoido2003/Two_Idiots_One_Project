using DSA.LinkedList;
using DSA.Sort;

int[] arr = { 5, 8, 7, 1, 2, 9 };

// LinkedList.Node root = LinkedList.CreateFromArray(arr);
// LinkedList.PrintList(root);

// SortTheory.BurbleSort(arr);
SortTheory.MergeSort2(arr, 0, arr.Length - 1);

// SortTheory.QuickSort(arr, 0, arr.Length - 1);

// SortTheory.HeapSort(arr);

for (int i = 0; i <= arr.Length - 1; i++)
{
    Console.Write(arr[i] + " ");
}
