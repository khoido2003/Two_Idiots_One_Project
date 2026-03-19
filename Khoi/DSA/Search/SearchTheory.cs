namespace DSA.LinkedList
{
    public class SearchTheory
    {
        public static bool BinarySearch(int[] arr, int key)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (arr[mid] == key)
                {
                    return true;
                }

                if (arr[mid] >= key)
                {
                    high = mid - 1;
                }

                if (arr[mid] < key)
                {
                    low = mid + 1;
                }
            }

            return false;
        }

        public static int LowerBound(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        public static int UpperBound(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] <= target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }
    }
}
