namespace DSA.PrefixSum
{
    public class PrefixSumTheory
    {
        public static List<int> PrefSum(int[] arr)
        {
            List<int> prefSum = new();
            prefSum.Add(arr[0]);

            for (int i = 1; i < arr.Length; i++)
            {
                prefSum.Add(prefSum[i - 1] + arr[i]);
            }

            return prefSum;
        }
    }
}
