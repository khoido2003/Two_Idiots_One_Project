namespace DSA.Search
{
    public class SearchPractice
    {
        // https://leetcode.com/problems/minimum-size-subarray-sum/submissions/1957718492/?envType=problem-list-v2&envId=binary-search
        public int MinSubArrayLen(int target, int[] nums)
        {
            int left = 0;
            int sum = 0;
            int minLen = int.MaxValue;

            for (int right = 0; right < nums.Length; right++)
            {
                sum += nums[right];

                while (sum >= target)
                {
                    minLen = Math.Min(minLen, right - left + 1);

                    sum -= nums[left];
                    left++;
                }
            }

            return minLen == int.MaxValue ? 0 : minLen;
        }

        ///////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/submissions/1957705969/?envType=problem-list-v2&envId=binary-search
        public int[] TwoSum(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left < right)
            {
                int curSum = 0;
                curSum += numbers[left] + numbers[right];

                if (curSum == target)
                {
                    return [left + 1, right + 1];
                }
                else if (curSum > target)
                {
                    right -= 1;
                }
                else
                {
                    left += 1;
                }
            }

            return [-1, -1];
        }

        //////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/find-peak-element/submissions/1957701747/?envType=problem-list-v2&envId=binary-search
        public int FindPeakElement(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] < nums[mid + 1])
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

        /////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/submissions/1957689274/?envType=problem-list-v2&envId=binary-search
        public int FindMin(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else if (nums[mid] <= nums[right])
                {
                    right = mid;
                }
            }

            return nums[left];
        }

        /////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/search-in-rotated-sorted-array-ii/submissions/1957680745/?envType=problem-list-v2&envId=binary-search

        public bool Search(int[] nums, int target)
        {
            Array.Sort(nums);

            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return true;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return false;
        }

        ///////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/search-a-2d-matrix/submissions/1957675070/?envType=problem-list-v2&envId=binary-search

        public bool SearchMatrix(int[][] matrix, int target)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                int left = 0;
                int right = matrix[i].Length - 1;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;

                    if (matrix[i][mid] == target)
                    {
                        return true;
                    }
                    else if (matrix[i][mid] < target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return false;
        }

        //////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/search-insert-position/submissions/1957664673/?envType=problem-list-v2&envId=binary-search

        public int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] < target)
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

        ///////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/?envType=problem-list-v2&envId=binary-search
        public int[] SearchRange(int[] nums, int target)
        {
            List<int> res = new();

            res.Add(-1);
            res.Add(-1);

            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    res[0] = mid;
                    right = mid - 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            left = 0;
            right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    res[1] = mid;
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return res.ToArray();
        }

        //////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/search-in-rotated-sorted-array/description/?envType=problem-list-v2&envId=binary-search

        private void Swap(List<(int index, int value)> ls, int a, int b)
        {
            (ls[a], ls[b]) = (ls[b], ls[a]);
        }

        private int Partition(List<(int index, int value)> ls, int low, int high)
        {
            int i = low - 1;
            int pivot = ls[high].value;

            for (int j = low; j < high; j++)
            {
                if (ls[j].value <= pivot)
                {
                    i++;
                    Swap(ls, i, j);
                }
            }

            Swap(ls, i + 1, high);

            return i + 1;
        }

        private void QuickSort(List<(int index, int value)> ls, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(ls, left, right);

                QuickSort(ls, left, pivot - 1);
                QuickSort(ls, pivot + 1, right);
            }
        }

        public int Search(int[] nums, int target)
        {
            List<(int index, int value)> list = new();

            for (int i = 0; i < nums.Length; i++)
            {
                list.Add((i, nums[i]));
            }

            QuickSort(list, 0, list.Count - 1);

            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (list[mid].value == target)
                {
                    return list[mid].index;
                }
                else if (list[mid].value > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }
    }
}
