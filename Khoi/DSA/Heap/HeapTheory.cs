namespace DSA.Heap
{
    public class HeapTheory
    {
        public static bool IsHeap(int[] arr, int n)
        {
            for (int i = 0; i <= (n - 2) / 2; i++)
            {
                if (arr[2 * i + 1] > arr[i])
                {
                    return false;
                }

                if (2 * i + 2 < n && arr[2 * i + 2] > arr[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static int HeightHeap(int[] arr)
        {
            int len = arr.Length;

            return (int)Math.Ceiling(Math.Log(len + 1) / Math.Log(2)) - 1;
        }
    }
}
