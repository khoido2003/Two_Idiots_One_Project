using System.Text;

namespace DSA.Backtracking
{
    public class BacktrackingPractice
    {
        // https://leetcode.com/problems/word-search/?envType=problem-list-v2&envId=backtracking

        public bool Exist(char[][] board, string word)
        {
            int[][] directions =
            {
                new int[] { -1, 0 },
                new int[] { 1, 0 },
                new int[] { 0, -1 },
                new int[] { 0, 1 },
            };

            StringBuilder curWord = new("");

            bool[][] visited = new bool[board.Length][];

            for (int i = 0; i < board.Length; i++)
            {
                visited[i] = new bool[board[i].Length];
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (BacktrackExist(directions, board, word, i, j, visited, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool BacktrackExist(
            int[][] directions,
            char[][] board,
            string word,
            int curX,
            int curY,
            bool[][] visited,
            int index
        )
        {
            if (curX < 0 || curY < 0 || curX >= board.Length || curY >= board[0].Length)
            {
                return false;
            }

            if (visited[curX][curY])
            {
                return false;
            }

            if (board[curX][curY] != word[index])
            {
                return false;
            }

            if (index == word.Length - 1)
            {
                return board[curX][curY] == word[index];
            }

            visited[curX][curY] = true;

            for (int i = 0; i < directions.Length; i++)
            {
                if (
                    BacktrackExist(
                        directions,
                        board,
                        word,
                        curX + directions[i][0],
                        curY + directions[i][1],
                        visited,
                        index + 1
                    )
                )
                {
                    return true;
                }
            }

            visited[curX][curY] = false;

            return false;
        }

        ////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/subsets/submissions/1960767891/?envType=problem-list-v2&envId=backtracking

        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> res = [];
            List<int> curGroup = [];

            BacktrackSubsets(nums, res, curGroup, 0);

            return res;
        }

        private void BacktrackSubsets(
            int[] nums,
            IList<IList<int>> res,
            List<int> curGroup,
            int start
        )
        {
            if (start > nums.Length)
            {
                return;
            }

            if (curGroup.Count <= nums.Length)
            {
                res.Add([.. curGroup]);
            }

            for (int i = start; i < nums.Length; i++)
            {
                curGroup.Add(nums[i]);

                BacktrackSubsets(nums, res, curGroup, i + 1);

                curGroup.RemoveAt(curGroup.Count - 1);
            }
        }

        ////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/combinations/submissions/1960750957/?envType=problem-list-v2&envId=backtracking
        public IList<IList<int>> Combine(int n, int k)
        {
            int[] nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = i + 1;
            }

            IList<IList<int>> res = [];
            List<int> curGroup = [];
            bool[] used = new bool[n];

            BacktrackCombine(nums, res, curGroup, used, k, 0);

            return res;
        }

        private void BacktrackCombine(
            int[] nums,
            IList<IList<int>> res,
            List<int> curGroup,
            bool[] used,
            int k,
            int start
        )
        {
            if (curGroup.Count == k)
            {
                res.Add([.. curGroup]);
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                if (used[i])
                {
                    continue;
                }

                used[i] = true;
                curGroup.Add(nums[i]);

                BacktrackCombine(nums, res, curGroup, used, k, i + 1);

                used[i] = false;
                curGroup.RemoveAt(curGroup.Count - 1);
            }
        }

        ///////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/permutations-ii/submissions/1960713311/?envType=problem-list-v2&envId=backtracking
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            Dictionary<int, bool> used = [];

            for (int i = 0; i < nums.Length; i++)
            {
                used[i] = false;
            }

            IList<IList<int>> res = [];
            List<int> curGroup = [];

            Array.Sort(nums);

            BacktrackPermuteUnique(nums, used, res, curGroup);

            return res;
        }

        private void BacktrackPermuteUnique(
            int[] nums,
            Dictionary<int, bool> used,
            IList<IList<int>> res,
            List<int> curGroup
        )
        {
            if (curGroup.Count == nums.Length)
            {
                res.Add([.. curGroup]);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
                {
                    continue;
                }

                if (used[i])
                {
                    continue;
                }

                used[i] = true;
                curGroup.Add(nums[i]);

                BacktrackPermuteUnique(nums, used, res, curGroup);

                used[i] = false;

                curGroup.RemoveAt(curGroup.Count - 1);
            }
        }

        /////////////////////////////////////////////////////////////////

        //https://leetcode.com/problems/permutations/submissions/1960623391/?envType=problem-list-v2&envId=backtracking

        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> res = [];

            Dictionary<int, bool> used = [];

            for (int i = 0; i < nums.Length; i++)
            {
                used[nums[i]] = false;
            }

            List<int> curGroup = [];

            BacktrackPermute(nums, used, res, curGroup);

            return res;
        }

        private void BacktrackPermute(
            int[] nums,
            Dictionary<int, bool> used,
            IList<IList<int>> res,
            List<int> curGroup
        )
        {
            if (curGroup.Count == nums.Length)
            {
                res.Add([.. curGroup]);

                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[nums[i]])
                {
                    continue;
                }

                used[nums[i]] = true;

                curGroup.Add(nums[i]);
                BacktrackPermute(nums, used, res, curGroup);

                curGroup.RemoveAt(curGroup.Count - 1);
                used[nums[i]] = false;
            }
        }

        ///////////////////////////////////////////////////////////////

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> res = [];
            Array.Sort(candidates);
            List<int> curEl = [];

            BacktrackCombinationSum2(candidates, target, 0, res, curEl, 0);

            return res;
        }

        private void BacktrackCombinationSum2(
            int[] candidates,
            int target,
            int curSum,
            IList<IList<int>> res,
            List<int> curEl,
            int curIndex
        )
        {
            if (target < curSum)
            {
                return;
            }

            if (target == curSum)
            {
                res.Add([.. curEl]);
                return;
            }

            for (int i = curIndex; i < candidates.Length; i++)
            {
                if (i > curIndex && candidates[i] == candidates[i - 1])
                {
                    continue;
                }

                curEl.Add(candidates[i]);

                BacktrackCombinationSum2(
                    candidates,
                    target,
                    curSum + candidates[i],
                    res,
                    curEl,
                    i + 1
                );

                curEl.RemoveAt(curEl.Count - 1);
            }
        }

        ///////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/combination-sum/submissions/1960223664/?envType=problem-list-v2&envId=backtracking
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> res = [];

            List<int> curEl = [];

            BacktrackCombinationSum(candidates, target, 0, res, curEl, 0);

            return res;
        }

        private void BacktrackCombinationSum(
            int[] candidates,
            int target,
            int curSum,
            IList<IList<int>> res,
            List<int> curEl,
            int curIndex
        )
        {
            if (target < curSum)
            {
                return;
            }

            if (target == curSum)
            {
                res.Add([.. curEl]);
                return;
            }

            for (int i = curIndex; i < candidates.Length; i++)
            {
                curEl.Add(candidates[i]);

                BacktrackCombinationSum(candidates, target, curSum + candidates[i], res, curEl, i);

                curEl.RemoveAt(curEl.Count - 1);
            }
        }

        ///////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/generate-parentheses/submissions/1960164265/?envType=problem-list-v2&envId=backtracking
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> res = [];

            StringBuilder curWord = new("");

            BacktrackGenerateParenthesis(curWord, 0, 0, n, res);

            return res;
        }

        private void BacktrackGenerateParenthesis(
            StringBuilder curWord,
            int open,
            int close,
            int n,
            IList<string> res
        )
        {
            if (curWord.Length == 2 * n)
            {
                res.Add(curWord.ToString());
                return;
            }

            if (open < n)
            {
                curWord.Append('(');

                BacktrackGenerateParenthesis(curWord, open + 1, close, n, res);

                curWord.Remove(curWord.Length - 1, 1);
            }

            if (close < open)
            {
                curWord.Append(')');

                BacktrackGenerateParenthesis(curWord, open, close + 1, n, res);

                curWord.Remove(curWord.Length - 1, 1);
            }
        }

        /////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/letter-combinations-of-a-phone-number/submissions/1960142182/?envType=problem-list-v2&envId=backtracking

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> res = new List<string>();
            Dictionary<char, List<string>> map = new()
            {
                { '2', ["a", "b", "c"] },
                { '3', ["d", "e", "f"] },
                { '4', ["g", "h", "i"] },
                { '5', ["j", "k", "l"] },
                { '6', ["m", "n", "o"] },
                { '7', ["p", "q", "r", "s"] },
                { '8', ["t", "u", "v"] },
                { '9', ["w", "x", "y", "z"] },
            };

            char[] digitsArr = digits.ToArray();

            StringBuilder curWorld = new("");

            BacktrackLetterCombination(digitsArr, res, map, curWorld, 0);

            return res;
        }

        private void BacktrackLetterCombination(
            char[] digitsArr,
            IList<string> res,
            Dictionary<char, List<string>> map,
            StringBuilder curWord,
            int index
        )
        {
            if (index == digitsArr.Length)
            {
                res.Add(curWord.ToString());
                return;
            }

            foreach (string val in map[digitsArr[index]])
            {
                curWord.Append(val);

                BacktrackLetterCombination(digitsArr, res, map, curWord, index + 1);

                curWord.Remove(curWord.Length - 1, 1);
            }
        }
    }
}
