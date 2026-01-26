namespace DSA.TwoPointer
{
    public class TwoPointerTheory
    {
        public static bool TwoSum(int[] arr, int target)
        {
            int left = 0,
                right = arr.Length - 1;

            while (left < right)
            {
                int curSum = left + right;

                if (curSum == target)
                {
                    return true;
                }

                if (curSum < target)
                {
                    left += 1;
                }

                if (curSum > target)
                {
                    right -= 1;
                }
            }

            return false;
        }
    }
}
