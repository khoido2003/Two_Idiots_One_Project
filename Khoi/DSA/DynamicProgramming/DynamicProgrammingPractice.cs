using System.Text;

namespace DSA.DynamicProgramming
{
    public class DynamicProgrammingPractice
    {
        // https://leetcode.com/problems/interleaving-string/submissions/1962689293/?envType=problem-list-v2&envId=dynamic-programming

        public bool IsInterleave(string s1, string s2, string s3)
        {
            int[][] memo = new int[s1.Length + 1][];

            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = new int[s2.Length + 1];

                Array.Fill(memo[i], -1);
            }

            if (s1.Length + s2.Length != s3.Length)
            {
                return false;
            }

            return DfsIsInterleave(s1, s2, s3, memo, 0, 0);
        }

        private bool DfsIsInterleave(string s1, string s2, string s3, int[][] memo, int i, int j)
        {
            if (i == s1.Length && j == s2.Length)
            {
                return true;
            }

            if (memo[i][j] != -1)
            {
                return memo[i][j] == 1;
            }

            int k = i + j;

            if (i < s1.Length && s1[i] == s3[k])
            {
                if (DfsIsInterleave(s1, s2, s3, memo, i + 1, j))
                {
                    memo[i][j] = 1;

                    return true;
                }
            }

            if (j < s2.Length && s2[j] == s3[k])
            {
                if (DfsIsInterleave(s1, s2, s3, memo, i, j + 1))
                {
                    memo[i][j] = 1;
                    return true;
                }
            }

            memo[i][j] = 0;
            return false;
        }

        /////////////////////////////////////////////////

        // https://leetcode.com/problems/decode-ways/?envType=problem-list-v2&envId=dynamic-programming

        public int NumDecodings(string s)
        {
            int[] memo = new int[s.Length];

            Array.Fill(memo, -1);

            return DfsNumDecodings(s, 0, memo);
        }

        private int DfsNumDecodings(string s, int i, int[] memo)
        {
            int ways = 0;
            if (i == s.Length)
            {
                return 1;
            }

            if (memo[i] != -1)
            {
                return memo[i];
            }

            if (s[i] == '0')
            {
                memo[i] = 0;
                return 0;
            }

            // Check 1 step
            ways += DfsNumDecodings(s, i + 1, memo);

            // Check 2 steps
            if (i + 1 < s.Length && (s[i] == '1' || (s[i] == '2' && s[i + 1] <= '6')))
            {
                ways += DfsNumDecodings(s, i + 2, memo);
            }

            return memo[i] = ways;
        }

        /////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/edit-distance/submissions/1962650399/?envType=problem-list-v2&envId=dynamic-programming

        public int MinDistance(string word1, string word2)
        {
            int[][] memo = new int[word1.Length][];

            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = new int[word2.Length];

                Array.Fill(memo[i], int.MaxValue);
            }

            return DfsMinDistanceWord(word1.ToCharArray(), word2.ToCharArray(), memo, 0, 0);
        }

        private int DfsMinDistanceWord(
            char[] word1Array,
            char[] word2Array,
            int[][] memo,
            int i,
            int j
        )
        {
            if (i == word1Array.Length)
            {
                // Insert the rest
                return word2Array.Length - j;
            }

            if (j == word2Array.Length)
            {
                // Remove all redundants
                return word1Array.Length - i;
            }

            if (memo[i][j] != int.MaxValue)
            {
                return memo[i][j];
            }

            if (word1Array[i] == word2Array[j])
            {
                return memo[i][j] = DfsMinDistanceWord(word1Array, word2Array, memo, i + 1, j + 1);
            }

            return memo[i][j] = Math.Min(
                // Insert
                1 + DfsMinDistanceWord(word1Array, word2Array, memo, i, j + 1),
                Math.Min(
                    // Replace
                    1 + DfsMinDistanceWord(word1Array, word2Array, memo, i + 1, j + 1),
                    // Delete
                    1 + DfsMinDistanceWord(word1Array, word2Array, memo, i + 1, j)
                )
            );
        }

        /////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/climbing-stairs/submissions/1962630900/?envType=problem-list-v2&envId=dynamic-programming
        public int ClimbStairs(int n)
        {
            int[] memo = new int[n];

            Array.Fill(memo, -1);

            return DfsClimbStairs(n, 0, memo);
        }

        private int DfsClimbStairs(int n, int i, int[] memo)
        {
            if (i >= n - 1)
            {
                return 1;
            }

            if (memo[i] != -1)
            {
                return memo[i];
            }

            return memo[i] = DfsClimbStairs(n, i + 1, memo) + DfsClimbStairs(n, i + 2, memo);
        }

        //////////////////////////////////////////////////////////////////
        // https://leetcode.com/problems/minimum-path-sum/submissions/1962622391/?envType=problem-list-v2&envId=dynamic-programming
        public int MinPathSum(int[][] grid)
        {
            int[][] memo = new int[grid.Length][];

            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = new int[grid[0].Length];

                Array.Fill(memo[i], int.MaxValue);
            }

            return DfsMinPathSum(grid, 0, 0, memo);
        }

        private int DfsMinPathSum(int[][] grid, int i, int j, int[][] memo)
        {
            if (i == grid.Length - 1 && j == grid[0].Length - 1)
            {
                memo[i][j] = grid[i][j];
                return grid[i][j];
            }

            if (i >= grid.Length || j >= grid[0].Length)
            {
                return int.MaxValue;
            }

            if (memo[i][j] != int.MaxValue)
            {
                return memo[i][j];
            }

            return memo[i][j] =
                grid[i][j]
                + Math.Min(
                    DfsMinPathSum(grid, i + 1, j, memo),
                    DfsMinPathSum(grid, i, j + 1, memo)
                );
        }

        //////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/unique-paths-ii/?envType=problem-list-v2&envId=dynamic-programming

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int[][] memo = new int[obstacleGrid.Length][];

            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = new int[obstacleGrid[0].Length];

                Array.Fill(memo[i], -1);
            }

            return DfsUniquePathObstacles(obstacleGrid, 0, 0, memo);
        }

        private int DfsUniquePathObstacles(int[][] obstacleGrid, int i, int j, int[][] memo)
        {
            if (
                i == obstacleGrid.Length - 1
                && j == obstacleGrid[0].Length - 1
                && obstacleGrid[i][j] == 1
            )
            {
                memo[i][j] = 0;
                return 0;
            }

            if (i == obstacleGrid.Length - 1 && j == obstacleGrid[0].Length - 1)
            {
                memo[i][j] = 1;
                return 1;
            }

            if (i >= obstacleGrid.Length || j >= obstacleGrid[0].Length)
            {
                return 0;
            }

            if (obstacleGrid[i][j] == 1)
            {
                memo[i][j] = 0;
                return 0;
            }

            if (memo[i][j] != -1)
            {
                return memo[i][j];
            }

            return memo[i][j] =
                DfsUniquePathObstacles(obstacleGrid, i + 1, j, memo)
                + DfsUniquePathObstacles(obstacleGrid, i, j + 1, memo);
        }

        ////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/unique-paths/submissions/1962128647/?envType=problem-list-v2&envId=dynamic-programming
        public int UniquePaths(int m, int n)
        {
            int[][] memo = new int[m][];

            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = new int[n];
                Array.Fill(memo[i], -1);
            }

            return DfsUniquePath(m, n, memo, 0, 0);
        }

        private int DfsUniquePath(int m, int n, int[][] memo, int i, int j)
        {
            if (i == m - 1 && j == n - 1)
            {
                return 1;
            }

            if (i >= m || j >= n)
            {
                return 0;
            }

            if (memo[i][j] != -1)
            {
                return memo[i][j];
            }

            return memo[i][j] =
                DfsUniquePath(m, n, memo, i + 1, j) + DfsUniquePath(m, n, memo, i, j + 1);
        }

        ////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/jump-game/submissions/1962066915/?envType=problem-list-v2&envId=dynamic-programming
        public bool CanJump(int[] nums)
        {
            int[] memo = new int[nums.Length];
            Array.Fill(memo, -1);

            return DfsCanJump(nums, 0, memo);
        }

        private bool DfsCanJump(int[] nums, int i, int[] memo)
        {
            if (i >= nums.Length - 1)
            {
                return true;
            }

            if (memo[i] != -1)
            {
                return memo[i] == 1;
            }

            for (int j = 1; j <= nums[i]; j++)
            {
                if (DfsCanJump(nums, j + i, memo))
                {
                    memo[i] = 1;
                    return true;
                }
            }

            memo[i] = 0;
            return false;
        }

        /////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/maximum-subarray/submissions/1962020030/?envType=problem-list-v2&envId=dynamic-programming
        public int MaxSubArray(int[] nums)
        {
            int max = int.MinValue;

            int[] memo = new int[nums.Length];
            Array.Fill(memo, int.MinValue);

            for (int i = 0; i < nums.Length; i++)
            {
                int curTotal = Dfs(nums, memo, i);

                max = Math.Max(max, curTotal);
            }
            return max;
        }

        private int Dfs(int[] nums, int[] memo, int i)
        {
            if (i == 0)
            {
                return nums[0];
            }

            if (memo[i] != int.MinValue)
            {
                return memo[i];
            }
            int extend = nums[i] + Dfs(nums, memo, i - 1);
            int startNew = nums[i];

            return memo[i] = Math.Max(startNew, extend);
        }

        ///////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/longest-palindromic-substring/submissions/1952894045/?envType=problem-list-v2&envId=dynamic-programming
        public string LongestPalindrome(string s)
        {
            char[] chars = s.ToCharArray();

            int start = 0;
            int end = 0;
            int max = int.MinValue;

            int[][] memo = new int[chars.Length][];
            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = new int[chars.Length];
                Array.Fill(memo[i], -1);
            }

            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = i; j < chars.Length; j++)
                {
                    bool result = IsPalidrome(chars, i, j, memo);

                    if (result)
                    {
                        max = Math.Max(max, j - i + 1);

                        if (max == j - i + 1)
                        {
                            start = i;
                            end = j;
                        }
                    }
                }
            }

            StringBuilder builder = new("");

            for (int i = start; i <= end; i++)
            {
                builder.Append(chars[i]);
            }
            return builder.ToString();
        }

        private bool IsPalidrome(char[] s, int i, int j, int[][] memo)
        {
            if (i >= j)
            {
                return true;
            }

            if (memo[i][j] != -1)
            {
                return memo[i][j] == 1;
            }

            if (s[i] != s[j])
            {
                memo[i][j] = 0;
                return false;
            }

            bool result = IsPalidrome(s, i + 1, j - 1, memo);

            memo[i][j] = result ? 1 : 0;

            return result;
        }
    }
}
