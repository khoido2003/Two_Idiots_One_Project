namespace DSA.SlidingWindow
{
    public class SlidingWindowTheory
    {
        public static int MaxSum(int[] arr, int n, int k)
        {
            if (k > n)
            {
                return -1;
            }

            int maxSum = 0;

            for (int i = 0; i < k; i++)
            {
                maxSum += arr[i];
            }

            int curSum = maxSum;
            for (int i = k; i < n; i++)
            {
                curSum = curSum - arr[i - k] + arr[k];

                if (curSum > maxSum)
                {
                    maxSum = curSum;
                }
            }

            return maxSum;
        }
    }
}
