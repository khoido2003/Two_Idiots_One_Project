namespace DSA.Sort
{
    public class SortTheory
    {
        public static void BurbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        //////////////////////////////////////////////////////////////////////

        public static void Merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] arr1 = new int[n1];
            int[] arr2 = new int[n2];

            for (int x = 0; x < n1; x++)
            {
                arr1[x] = arr[x + l];
            }

            for (int x = 0; x < n2; x++)
            {
                arr2[x] = arr[x + m + 1];
            }

            int k = l;
            int i = 0,
                j = 0;

            while (i < n1 && j < n2)
            {
                if (arr1[i] <= arr2[j])
                {
                    arr[k] = arr1[i];
                    i++;
                }
                else if (arr1[i] > arr2[j])
                {
                    arr[k] = arr2[j];
                    j++;
                }

                k++;
            }

            while (i < n1)
            {
                arr[k] = arr1[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = arr2[j];
                j++;
                k++;
            }
        }

        public static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);

                Merge(arr, l, m, r);
            }
        }

        ////////////////////////////////////////////////////////

        public static int Patition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1;
        }

        public static void Swap(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        public static void QuickSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int p = Patition(arr, l, r);

                QuickSort(arr, l, p - 1);
                QuickSort(arr, p + 1, r);
            }
        }

        //////////////////////////////////////////////////////////////////////

        public static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[largest] < arr[left])
            {
                largest = left;
            }

            if (right < n && arr[largest] < arr[right])
            {
                largest = right;
            }

            if (largest != i)
            {
                int tmp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = tmp;

                Heapify(arr, n, largest);
            }
        }

        public static void HeapSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = (n - 1) / 2; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int tmp = arr[0];
                arr[0] = arr[i];
                arr[i] = tmp;

                Heapify(arr, i, 0);
            }
        }

        //////////////////////////////////////////////////////////////////
    }
}
