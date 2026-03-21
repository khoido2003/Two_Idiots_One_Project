namespace DSA.Sort
{
    public class SortPractice
    {
        // https://leetcode.com/problems/maximum-gap/submissions/1952828321/?envType=problem-list-v2&envId=sorting
        public int MaximumGap(int[] nums)
        {
            if (nums.Length < 2)
            {
                return 0;
            }
            Array.Sort(nums);

            int curMax = int.MinValue;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int curCmp = Math.Abs(nums[i] - nums[i + 1]);

                if (curCmp > curMax)
                {
                    curMax = curCmp;
                }
            }

            return curMax;
        }

        //////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/sort-list/submissions/1952811560/?envType=problem-list-v2&envId=sorting

        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        private ListNode Merge(ListNode left, ListNode right)
        {
            ListNode dummy = new ListNode();

            ListNode tail = dummy;

            while (left != null && right != null)
            {
                if (left.val <= right.val)
                {
                    tail.next = left;
                    left = left.next;
                }
                else if (right.val < left.val)
                {
                    tail.next = right;
                    right = right.next;
                }

                tail = tail.next;
            }

            while (left != null)
            {
                tail.next = left;
                left = left.next;
                tail = tail.next;
            }

            while (right != null)
            {
                tail.next = right;
                right = right.next;
                tail = tail.next;
            }

            return dummy.next;
        }

        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode prev = null;
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = null;

            ListNode left = SortList(head);
            ListNode right = SortList(slow);

            return Merge(left, right);
        }

        ///////////////////////////////////////////////////////////

        // https://leetcode.com/problems/merge-sorted-array/submissions/1952786877/?envType=problem-list-v2&envId=sorting

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] res = new int[m + n];

            int i = 0;
            int j = 0;
            int z = 0;

            while (i < m && j < n)
            {
                if (nums1[i] <= nums2[j])
                {
                    res[z] = nums1[i];
                    z++;
                    i++;
                }
                else
                {
                    res[z] = nums2[j];
                    z++;
                    j++;
                }
            }

            while (i < m)
            {
                res[z] = nums1[i];
                z++;
                i++;
            }

            while (j < n)
            {
                res[z] = nums2[j];
                z++;
                j++;
            }

            for (int x = 0; x < m + n; x++)
            {
                nums1[x] = res[x];
            }
        }

        ///////////////////////////////////////////////////////

        //https://leetcode.com/problems/merge-intervals/submissions/1702329704/?envType=problem-list-v2&envId=sorting
        private void SwapMergerInterval(int[][] intervals, int a, int b)
        {
            int[] tmp = intervals[a];
            intervals[a] = intervals[b];
            intervals[b] = tmp;
        }

        private int PartitionMergeInterval(int[][] intervals, int low, int high)
        {
            int i = low - 1;

            int pivot = intervals[high][0];

            for (int j = low; j < high; j++)
            {
                if (intervals[j][0] < pivot)
                {
                    i++;
                    SwapMergerInterval(intervals, i, j);
                }
            }

            SwapMergerInterval(intervals, i + 1, high);
            return i + 1;
        }

        private void QuickSortMergeInterval(int[][] intervals, int left, int right)
        {
            if (left < right)
            {
                int p = PartitionMergeInterval(intervals, left, right);

                QuickSortMergeInterval(intervals, left, p - 1);
                QuickSortMergeInterval(intervals, p + 1, right);
            }
        }

        public int[][] Merge(int[][] intervals)
        {
            QuickSortMergeInterval(intervals, 0, intervals.Length - 1);

            List<List<int>> res = new();

            int i = 0;
            int j = 0;
            int curMax = intervals[0][1];

            res.Add([intervals[0][0], intervals[0][1]]);

            while (i < intervals.Length)
            {
                int start = intervals[i][0];
                int end = intervals[i][1];

                if (start <= curMax)
                {
                    curMax = Math.Max(curMax, end);

                    res[j][1] = curMax;
                }
                else
                {
                    res.Add([]);
                    j++;
                    res[j] = [start, end];
                    curMax = Math.Max(curMax, end);
                }

                i++;
            }

            int[][] result = new int[res.Count][];

            for (int x = 0; x < res.Count; x++)
            {
                result[x] = new int[2];

                for (int y = 0; y < 2; y++)
                {
                    result[x][y] = res[x][y];
                }
            }

            return result;
        }

        /////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/group-anagrams/submissions/1952734691/?envType=problem-list-v2&envId=sorting
        private void Swap(char[] str, int a, int b)
        {
            char tmp = str[a];
            str[a] = str[b];
            str[b] = tmp;
        }

        private int PartitionAnagrams(char[] str, int low, int high)
        {
            int i = low - 1;

            char pivot = str[high];

            for (int j = low; j < high; j++)
            {
                if (str[j] - 'a' < pivot - 'a')
                {
                    i++;

                    Swap(str, i, j);
                }
            }

            Swap(str, i + 1, high);
            return i + 1;
        }

        private void QuickSortAnagrams(char[] str, int left, int right)
        {
            if (left < right)
            {
                int p = PartitionAnagrams(str, left, right);

                QuickSortAnagrams(str, left, p - 1);
                QuickSortAnagrams(str, p + 1, right);
            }
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> res = new List<IList<string>>();

            Dictionary<string, List<string>> map = new();

            for (int i = 0; i < strs.Length; i++)
            {
                string curStr = strs[i];
                char[] chars = curStr.ToCharArray();

                QuickSortAnagrams(chars, 0, chars.Length - 1);

                string sortedStr = "";
                foreach (char c in chars)
                {
                    sortedStr += c;
                }

                if (map.ContainsKey(sortedStr))
                {
                    map[sortedStr].Add(curStr);
                }
                else
                {
                    map[sortedStr] = new List<string>();
                    map[sortedStr].Add(curStr);
                }
            }

            foreach (var ls in map.Values)
            {
                res.Add(new List<string>(ls));
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/permutations-ii/submissions/1952708210/?envType=problem-list-v2&envId=sorting
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<int> ls = nums.ToList();

            ls.Sort((a, b) => a - b);

            List<int> curLs = [];

            IList<IList<int>> res = [];

            bool[] visited = new bool[ls.Count];

            int max = ls.Count;

            BacktrackPermutationUnique(max, ls, curLs, visited, res);

            return res;
        }

        private void BacktrackPermutationUnique(
            int max,
            List<int> nums,
            List<int> curLs,
            bool[] visited,
            IList<IList<int>> res
        )
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1] && !visited[i - 1])
                {
                    continue;
                }

                if (visited[i])
                {
                    continue;
                }

                curLs.Add(nums[i]);

                visited[i] = true;

                if (curLs.Count == max)
                {
                    res.Add(new List<int>(curLs));
                }

                BacktrackPermutationUnique(max, nums, curLs, visited, res);

                visited[i] = false;

                curLs.RemoveAt(curLs.Count - 1);
            }
        }

        /////////////////////////////////////////////////////////////////

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);

            IList<IList<int>> res = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                    {
                        continue;
                    }
                    int left = j + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        long curSum = (long)nums[i] + nums[j] + nums[left] + nums[right];

                        if (curSum < target)
                        {
                            left++;
                        }
                        else if (curSum > target)
                        {
                            right--;
                        }
                        else
                        {
                            res.Add([nums[i], nums[j], nums[left], nums[right]]);

                            left++;
                            right--;

                            while (left < right && nums[left] == nums[left - 1])
                            {
                                left++;
                            }

                            while (left < right && nums[right] == nums[right + 1])
                            {
                                right--;
                            }
                        }
                    }
                }
            }

            return res;
        }

        ////////////////////////////////////////////////////////////////

        // 3Sum Closest: https://leetcode.com/problems/3sum-closest/description/?envType=problem-list-v2&envId=sorting

        public int ThreeSumClosest(int[] nums, int target)
        {
            QuickSort(nums, 0, nums.Length - 1);

            int cmp = int.MaxValue;
            int res = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;

                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                while (left < right)
                {
                    int curSum = nums[i] + nums[left] + nums[right];
                    int curCmp = 0;

                    if (curSum <= target)
                    {
                        curCmp = Math.Abs(curSum - target);
                        left++;
                    }
                    else if (curSum > target)
                    {
                        curCmp = Math.Abs(curSum - target);
                        right--;
                    }

                    if (cmp > curCmp)
                    {
                        cmp = curCmp;
                        res = curSum;
                    }
                }
            }

            return res;
        }

        ///////////////////////////////////////////////////

        // 3Sum: https://leetcode.com/problems/3sum/description/?envType=problem-list-v2&envId=sorting
        private void Swap(int[] nums, int a, int b)
        {
            int tmp = nums[a];
            nums[a] = nums[b];
            nums[b] = tmp;
        }

        private int Partition(int[] nums, int low, int high)
        {
            int i = low - 1;
            int pivot = nums[high];

            for (int j = low; j < high; j++)
            {
                if (nums[j] < pivot)
                {
                    i++;
                    Swap(nums, i, j);
                }
            }

            Swap(nums, i + 1, high);
            return i + 1;
        }

        private void QuickSort(int[] nums, int left, int right)
        {
            if (left < right)
            {
                int p = Partition(nums, left, right);

                QuickSort(nums, left, p - 1);
                QuickSort(nums, p + 1, right);
            }
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();

            QuickSort(nums, 0, nums.Length - 1);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int curSum = nums[i] + nums[left] + nums[right];

                    if (curSum > 0)
                    {
                        right -= 1;
                    }
                    else if (curSum < 0)
                    {
                        left += 1;
                    }
                    else
                    {
                        res.Add([nums[i], nums[left], nums[right]]);
                        left++;
                        right--;

                        while (left < right && nums[left] == nums[left - 1])
                        {
                            left++;
                        }

                        while (left < right && nums[right] == nums[right + 1])
                        {
                            right--;
                        }
                    }
                }
            }

            return res;
        }
    }
}
