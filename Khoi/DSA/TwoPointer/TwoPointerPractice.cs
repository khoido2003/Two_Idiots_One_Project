namespace DSA.TwoPointer
{
    public class TwoPointerPractice
    {
        // https://leetcode.com/problems/reverse-words-in-a-string/submissions/1953301610/?envType=problem-list-v2&envId=two-pointers
        public string ReverseWords(string s)
        {
            string[] strs = s.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int left = 0;
            int right = strs.Length - 1;

            while (left < right)
            {
                (strs[left], strs[right]) = (strs[right], strs[left]);
                left++;
                right--;
            }

            string res = "";
            foreach (var el in strs)
            {
                res += el + " ";
            }

            return res.Trim();
        }

        ////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/rotate-list/description/?envType=problem-list-v2&envId=two-pointers

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

        private ListNode ReverseListNode(ListNode head)
        {
            ListNode prev = null;
            ListNode cur = head;
            ListNode next = null;

            while (cur != null)
            {
                next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }

            head = prev;
            return head;
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode dummy1 = head;
            ListNode dummy2 = head;

            int cnt = 0;

            while (dummy1 != null)
            {
                cnt++;
                dummy1 = dummy1.next;
            }

            k = k % cnt;

            if (k == 0)
            {
                return head;
            }

            int targetPos = cnt - k;

            if (targetPos == 0)
            {
                return head;
            }

            int i = 0;
            ListNode foundTarget = null;
            ListNode prevDummy2 = null;

            while (dummy2 != null)
            {
                if (i == targetPos)
                {
                    foundTarget = dummy2;

                    break;
                }
                i++;
                prevDummy2 = dummy2;
                dummy2 = dummy2.next;
            }

            prevDummy2.next = null;

            ListNode newHead = foundTarget;
            ListNode tail = foundTarget;

            while (tail.next != null)
            {
                tail = tail.next;
            }

            tail.next = head;

            return newHead;
        }

        /////////////////////////////////////////////////

        // https://leetcode.com/problems/next-permutation/submissions/1953186000/?envType=problem-list-v2&envId=two-pointers

        private void ReversePermutation(int[] nums, int startPos)
        {
            int left = startPos;
            int right = nums.Length - 1;

            while (left < right)
            {
                SwapPermutations(nums, left, right);
                left++;
                right--;
            }
        }

        private void SwapPermutations(int[] nums, int a, int b)
        {
            (nums[a], nums[b]) = (nums[b], nums[a]);
        }

        public void NextPermutation(int[] nums)
        {
            int n = nums.Length;
            int i = n - 2;
            int j = n - 1;

            while (i >= 0)
            {
                if (nums[i] >= nums[i + 1])
                {
                    i--;
                }
                else
                {
                    break;
                }
            }

            if (i < 0)
            {
                ReversePermutation(nums, 0);
                return;
            }

            while (j >= 0)
            {
                if (nums[j] <= nums[i])
                {
                    j--;
                }
                else
                {
                    break;
                }
            }

            SwapPermutations(nums, i, j);

            ReversePermutation(nums, i + 1);
        }

        /////////////////////////////////////////////////////

        // leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/description/?envType=problem-list-v2&envId=two-pointers

        public int StrStr(string haystack, string needle)
        {
            int maxLen = needle.Length;

            for (int i = 0; i <= haystack.Length - maxLen; i++)
            {
                int j = 0;
                string curWord = "";
                while (j < maxLen)
                {
                    curWord = curWord + haystack[i + j];
                    j++;
                }

                if (curWord == needle)
                {
                    return i;
                }
            }

            return -1;
        }

        //////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/remove-duplicates-from-sorted-array/submissions/1952926471/?envType=problem-list-v2&envId=two-pointers
        public int RemoveDuplicates(int[] nums)
        {
            HashSet<int> set = new(nums);
            List<int> ls = set.ToList();

            int res = ls.Count;

            for (int i = 0; i < res; i++)
            {
                nums[i] = ls[i];
            }

            return res;
        }

        //////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/remove-nth-node-from-end-of-list/solutions/7573886/beats-100-one-pass-solution-java-c-pytho-oc4j/?envType=problem-list-v2&envId=two-pointers

        // public class ListNode
        // {
        //     public int val;
        //     public ListNode next;
        //
        //     public ListNode(int val = 0, ListNode next = null)
        //     {
        //         this.val = val;
        //         this.next = next;
        //     }
        // }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null && n >= 1)
            {
                return null;
            }

            ListNode dummy = head;
            ListNode dummy2 = head;

            int i = 0;

            int cnt = 0;

            while (dummy2 != null)
            {
                cnt++;
                dummy2 = dummy2.next;
            }

            ListNode prev = null;

            while (dummy != null)
            {
                if (i == cnt - n && prev == null)
                {
                    return head.next;
                }

                if (i == cnt - n)
                {
                    prev.next = dummy.next;

                    break;
                }

                i++;

                prev = dummy;
                dummy = dummy.next;
            }

            return head;
        }

        ///////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/container-with-most-water/submissions/1952906350/?envType=problem-list-v2&envId=two-pointers

        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;

            int max = int.MinValue;

            while (left < right)
            {
                int curHeight = Math.Min(height[left], height[right]);
                int curWidth = right - left;

                int area = curHeight * curWidth;

                if (max < area)
                {
                    max = area;
                }

                if (height[left] == curHeight)
                {
                    left++;
                }
                else if (height[right] == curHeight)
                {
                    right--;
                }
            }

            return max;
        }

        /////////////////////////////////////////////////////

        //  https://leetcode.com/problems/longest-palindromic-substring/submissions/1952894045/?envType=problem-list-v2&envId=two-pointers

        public string LongestPalindrome(string s)
        {
            char[] chars = s.ToCharArray();

            string res = "";
            int curMax = int.MinValue;

            for (int i = 0; i < chars.Length; i++)
            {
                int left = i;
                int right = i + 1;
                string curStr = "";

                while (left >= 0 && right < chars.Length && chars[left] == chars[right])
                {
                    curStr = chars[left] + curStr + chars[right];
                    left--;
                    right++;
                }

                int len = curStr.Length;

                if (len > curMax)
                {
                    curMax = len;
                    res = curStr;
                }

                left = i - 1;
                right = i + 1;
                curStr = "";
                curStr += chars[i];

                while (left >= 0 && right < chars.Length && chars[left] == chars[right])
                {
                    curStr = chars[left] + curStr + chars[right];
                    left--;
                    right++;
                }

                len = curStr.Length;
                if (len > curMax)
                {
                    curMax = len;
                    res = curStr;
                }
            }

            return res;
        }
    }
}
