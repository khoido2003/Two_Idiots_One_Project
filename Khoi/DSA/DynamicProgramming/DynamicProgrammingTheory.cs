namespace DSA.DynamicProgramming
{
    public class DynamicProgrammingTheory
    {
        private static int Stirling(int n, int k, int[,] memo)
        {
            if (n == 0 && k == 0)
            {
                return 1;
            }

            if (k == 0 || n == 0)
            {
                return 0;
            }

            if (n == k)
            {
                return 1;
            }

            if (k == 1)
            {
                return 1;
            }

            if (memo[n, k] != -1)
            {
                return memo[n, k];
            }

            return memo[n, k] = k * Stirling(n - 1, k, memo) + Stirling(n - 1, k - 1, memo);
        }

        public static int BellNumber(int n)
        {
            int[,] memo = new int[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
            for (int j = 0; j <= n; j++)
                memo[i, j] = -1;
            int result = 0;

            // Sum up Stirling numbers S(n, k) for all k from 1
            // to n
            for (int k = 1; k <= n; ++k)
            {
                result += Stirling(n, k, memo);
            }
            return result;
        }

        /////////////////////////////////////////////////////////////

        public static int MinSquares(int n, int[] memo)
        {
            if (n == 0)
                return n;

            if (memo[n] != -1)
            {
                return memo[n];
            }
            int cnt = n;

            for (int i = 1; i * i <= n; i++)
            {
                cnt = Math.Min(1 + MinSquares(n - i * i, memo), cnt);
            }

            return memo[n] = cnt;
        }

        //////////////////////////////////////////////////////////////

        public static int MinimumSumPathInTriangle(int[][] triangle, int i, int j, int[] memo)
        {
            if (i == triangle.Length)
            {
                return 0;
            }

            if (memo[i] != -1)
            {
                return memo[i];
            }

            return memo[i] =
                triangle[i][j]
                + Math.Min(
                    MinimumSumPathInTriangle(triangle, i + 1, j, memo),
                    MinimumSumPathInTriangle(triangle, i + 1, j + 1, memo)
                );
        }

        //////////////////////////////////////////////////////////////////

        private static int CountPairs(int k, int[] memo)
        {
            if (k == 0)
            {
                return 1;
            }

            if (memo[k] != -1)
            {
                return memo[k];
            }

            int total = 0;

            for (int i = 0; i < k; i++)
            {
                int left = CountPairs(i, memo);
                int right = CountPairs(k - i - 1, memo);

                total += left * right;
            }

            memo[k] = total;

            return total;
        }

        public static int CountValidParentheses(int n)
        {
            if (n % 2 != 0)
            {
                return 0;
            }

            int k = n / 2;

            int[] memo = new int[k + 1];
            for (int i = 0; i <= k; i++)
            {
                memo[i] = -1;
            }

            return CountPairs(k, memo);
        }

        //////////////////////////////////////////////////////////////

        private static int CalcFactorial(int n, int[] memo)
        {
            if (n == 0 || n == 1)
                return 1;

            if (memo[n] != -1)
            {
                return memo[n];
            }

            return memo[n] = CalcFactorial(n - 1, memo) * n;
        }

        private static int CalcCatalan(int n)
        {
            int[] memo = new int[2 * n + 1];

            for (int i = 0; i <= 2 * n; i++)
            {
                memo[i] = -1;
            }

            return CalcFactorial(2 * n, memo)
                / (CalcFactorial(n + 1, memo) * CalcFactorial(n, memo));
        }

        public static int CalcNthCatalanNumber(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += CalcCatalan(i) * CalcCatalan(n - i - 1);
            }

            return sum;
        }

        ///////////////////////////////////////////////////////////////

        public static int MaximizeNumberOfSegmments(int n, int x, int y, int z, int[] memo)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n < 0)
            {
                return -1;
            }

            if (memo[n] != -1)
            {
                return memo[n];
            }

            int cut1 = MaximizeNumberOfSegmments(n - x, x, y, z, memo);
            int cut2 = MaximizeNumberOfSegmments(n - y, x, y, z, memo);
            int cut3 = MaximizeNumberOfSegmments(n - z, x, y, z, memo);

            int max = -1;

            if (cut1 != -1)
                max = Math.Max(max, 1 + cut1);
            if (cut2 != -1)
                max = Math.Max(max, 1 + cut2);
            if (cut3 != -1)
                max = Math.Max(max, 1 + cut3);

            return memo[n] = max;
        }

        ////////////////////////////////////////////////////////////

        private static int MinCostRecur(int[] cost, int i, int[] dp)
        {
            if (i == 0)
            {
                return cost[0];
            }

            if (i == 1)
            {
                return cost[1];
            }

            if (dp[i] != -1)
            {
                return dp[i];
            }

            return dp[i] =
                cost[i] + Math.Min(MinCostRecur(cost, i - 1, dp), MinCostRecur(cost, i - 2, dp));
        }

        public static int CostToReachTheTop(int[] cost, int n)
        {
            if (n == 1)
            {
                return cost[0];
            }

            int[] memo = new int[n];
            for (int i = 0; i < n; i++)
                memo[i] = -1;

            return Math.Min(MinCostRecur(cost, n - 1, memo), MinCostRecur(cost, n - 2, memo));
        }

        ///////////////////////////////////////////////////////

        public static int Tribonacci(int n, List<int> dp)
        {
            if (n == 0 || n == 1)
            {
                return 0;
            }

            if (n == 2 || n == 3)
            {
                return 1;
            }

            if (dp[n] != -1)
            {
                return dp[n];
            }

            return dp[n] = Tribonacci(n - 1, dp) + Tribonacci(n - 2, dp) + Tribonacci(n - 3, dp);
        }

        ///////////////////////////////////////////////////////////////////

        public static int Fibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            int[] dp = new int[n + 1];

            dp[0] = 0;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        /////////////////////////////////////////////////////////////

        public static int Knapsack(int W, int[] profit, int[] weight)
        {
            int[][] dp = new int[weight.Length + 1][];

            for (int i = 0; i <= weight.Length; i++)
            {
                dp[i] = new int[W + 1];
            }

            for (int i = 1; i <= weight.Length; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    // Skip item
                    dp[i][w] = dp[i - 1][w];

                    // Accept item
                    if (weight[i - 1] <= w)
                    {
                        int take = profit[i - 1] + dp[i - 1][w - weight[i - 1]];

                        dp[i][w] = Math.Max(dp[i - 1][w], take);
                    }
                }
            }
            return dp[weight.Length][W];
        }

        /////////////////////////////////////////////////////////////////

        public static int ClimbStairs(int n)
        {
            int[] dp = new int[n + 1];

            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        ///////////////////////////////////////////////////////////////////

        public static int RodCutting(int[] price)
        {
            int n = price.Length;

            int[] dp = new int[n + 1];

            dp[0] = 1;

            for (int i = 0; i < n; i++)
            {
                int best = int.MinValue;

                for (int j = 0; j < i; j++)
                {
                    best = Math.Max(best, price[j] + dp[i - j - 1]);
                }
                dp[i] = best;
            }
            return dp[n];
        }
    }
}
