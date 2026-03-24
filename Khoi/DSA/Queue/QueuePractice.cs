using System.Collections.Generic;

namespace DSA.Queue
{
    public class QueuePractice
    {
        // https://leetcode.com/problems/number-of-people-aware-of-a-secret/?envType=problem-list-v2&envId=queue

        public int PeopleAwareOfSecret(int n, int delay, int forget)
        {
            int MOD = 1000000000 + 7;

            LinkedList<(int curDay, long totalPeopleLearned)> dequeu = new();
            long[] dp = new long[n];

            dp[0] = 1;

            long activeSharers = 0;
            dequeu.AddLast((0, 1));

            for (int i = 1; i < n; i++)
            {
                if (i - delay >= 0)
                {
                    activeSharers = (activeSharers + dp[i - delay]) % MOD;
                }

                if (i - forget >= 0)
                {
                    activeSharers = (activeSharers - dp[i - forget] + MOD) % MOD;
                }
                activeSharers = (activeSharers + MOD) % MOD;

                dp[i] = activeSharers;
            }

            long res = 0;

            for (int i = n - forget; i < n; i++)
            {
                if (i >= 0)
                {
                    res = (res + dp[i]) % MOD;
                }
            }

            return (int)res;
        }

        ////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/time-needed-to-buy-tickets/?envType=problem-list-v2&envId=queue

        public int TimeRequiredToBuy(int[] tickets, int k)
        {
            LinkedList<(int index, int total)> deque = new();

            int cnt = 0;

            for (int i = 0; i < tickets.Length; i++)
            {
                deque.AddLast((i, tickets[i]));
            }

            while (deque.Count > 0)
            {
                (int curIndex, int curTotal) = deque.First.Value;
                cnt++;
                curTotal--;

                if (curIndex == k && curTotal == 0)
                {
                    break;
                }

                if (curTotal == 0)
                {
                    deque.RemoveFirst();
                    continue;
                }

                deque.RemoveFirst();
                deque.AddLast((curIndex, curTotal));
            }

            return cnt;
        }

        /////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/find-the-winner-of-the-circular-game/submissions/1957061128/?envType=problem-list-v2&envId=queue

        public int FindTheWinner(int n, int k)
        {
            LinkedList<int> deque = new();

            int curCnt = k;

            for (int i = 1; i <= n; i++)
            {
                deque.AddLast(i);
            }

            while (deque.Count > 1)
            {
                while (curCnt > 1)
                {
                    curCnt--;

                    int curPlayer = deque.First.Value;
                    deque.RemoveFirst();
                    deque.AddLast(curPlayer);
                }

                deque.RemoveFirst();
                curCnt = k;
            }

            return deque.First.Value;
        }

        ///////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/submissions/1957034540/?envType=problem-list-v2&envId=queue
        public int CountStudents(int[] students, int[] sandwiches)
        {
            LinkedList<int> queueStu = new();
            LinkedList<int> queueSand = new();

            for (int i = 0; i < students.Length; i++)
            {
                queueStu.AddLast(students[i]);
                queueSand.AddLast(sandwiches[i]);
            }

            int cnt = 0;
            while (queueStu.Count > 0 && queueSand.Count > 0)
            {
                int curStu = queueStu.First.Value;
                int curSand = queueSand.First.Value;

                if (curStu == curSand)
                {
                    cnt = 0;
                    queueStu.RemoveFirst();
                    queueSand.RemoveFirst();
                }
                else
                {
                    cnt++;
                    queueStu.RemoveFirst();
                    queueStu.AddLast(curStu);
                }

                if (cnt == queueStu.Count)
                {
                    break;
                }
            }

            return queueStu.Count;
        }

        //////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/jump-game-vi/?envType=problem-list-v2&envId=queue
        public int MaxResult(int[] nums, int k)
        {
            int[] dp = new int[nums.Length];

            LinkedList<int> deque = new();

            dp[0] = nums[0];
            deque.AddFirst(0);

            for (int i = 1; i <= nums.Length - 1; i++)
            {
                while (deque.Count > 0 && deque.First.Value < i - k)
                {
                    deque.RemoveFirst();
                }

                dp[i] = nums[i] + dp[deque.First.Value];

                while (deque.Count > 0 && dp[deque.Last.Value] < dp[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);
            }

            return dp[nums.Length - 1];
        }

        ////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/submissions/1956864714/?envType=problem-list-v2&envId=queue

        public int LongestSubarray(int[] nums, int limit)
        {
            int n = nums.Length;

            LinkedList<int> maxQueue = new();
            LinkedList<int> minQueue = new();

            int left = 0;

            int max = int.MinValue;

            for (int right = 0; right <= n - 1; right++)
            {
                while (maxQueue.Count() > 0 && nums[right] > maxQueue.Last.Value)
                {
                    maxQueue.RemoveLast();
                }

                maxQueue.AddLast(nums[right]);

                while (minQueue.Count() > 0 && nums[right] < minQueue.Last.Value)
                {
                    minQueue.RemoveLast();
                }

                minQueue.AddLast(nums[right]);

                while (maxQueue.First.Value - minQueue.First.Value > limit)
                {
                    if (nums[left] == maxQueue.First.Value)
                    {
                        maxQueue.RemoveFirst();
                    }

                    if (nums[left] == minQueue.First.Value)
                    {
                        minQueue.RemoveFirst();
                    }

                    left++;
                }

                max = Math.Max(max, right - left + 1);
            }

            return max;
        }

        /////////////////////////////////////////////////////////

        // https://leetcode.com/problems/reveal-cards-in-increasing-order/submissions/1956449252/?envType=problem-list-v2&envId=queue
        public int[] DeckRevealedIncreasing(int[] deck)
        {
            LinkedList<int> list = new();

            Array.Sort(deck);

            list.AddFirst(deck[deck.Length - 1]);

            for (int i = deck.Length - 2; i >= 0; i--)
            {
                int topEl = list.Last.Value;
                list.RemoveLast();

                list.AddFirst(topEl);
                list.AddFirst(deck[i]);
            }

            int[] res = new int[deck.Length];

            int j = 0;
            while (list.Count > 0)
            {
                int el = list.First.Value;
                list.RemoveFirst();

                res[j] = el;

                j++;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////

        // https://leetcode.com/problems/number-of-recent-calls/?envType=problem-list-v2&envId=queue

        public class RecentCounter
        {
            Queue<int> queue = new();

            public RecentCounter()
            {
                queue = new();
            }

            public int Ping(int t)
            {
                queue.Enqueue(t);

                while (queue.Count > 0 && queue.Peek() < (t - 3000))
                {
                    queue.Dequeue();
                }

                return queue.Count;
            }
        }

        //////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/dota2-senate?envType=problem-list-v2&envId=queue
        public string PredictPartyVictory(string senate)
        {
            Queue<int> queueR = new();
            Queue<int> queueD = new();

            int n = senate.Length;

            for (int i = 0; i < n; i++)
            {
                if (senate[i] == 'R')
                {
                    queueR.Enqueue(i);
                }
                else
                {
                    queueD.Enqueue(i);
                }
            }

            while (queueR.Count > 0 && queueD.Count > 0)
            {
                int r = queueR.Dequeue();
                int d = queueD.Dequeue();

                if (r < d)
                {
                    // R acts first, bans D
                    queueR.Enqueue(r + n);
                }
                else
                {
                    // D acts first, bans R
                    queueD.Enqueue(d + n);
                }
            }

            return queueR.Count > 0 ? "Radiant" : "Dire";
        }

        ////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/first-unique-character-in-a-string/submissions/1955883928/?envType=problem-list-v2&envId=queue

        public int FirstUniqChar(string s)
        {
            Dictionary<char, (int, int)> map = new();

            char[] chars = s.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (!map.ContainsKey(chars[i]))
                {
                    map[chars[i]] = (i, 1);
                }
                else
                {
                    (int index, int amount) = map[chars[i]];

                    map[chars[i]] = (index, amount + 1);
                }
            }

            foreach (var (el, (index, amount)) in map)
            {
                if (amount == 1)
                {
                    return index;
                }
            }

            return -1;
        }

        ///////////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/flatten-nested-list-iterator/submissions/1955865794/?envType=problem-list-v2&envId=queue

        public interface NestedInteger
        {
            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            bool IsInteger();

            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            int GetInteger();

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            IList<NestedInteger> GetList();
        }

        public class NestedIterator
        {
            Queue<int> queue = new();

            public NestedIterator(IList<NestedInteger> nestedList)
            {
                Flatten(nestedList);
            }

            private void Flatten(IList<NestedInteger> nestedList)
            {
                foreach (var el in nestedList)
                {
                    if (el.IsInteger())
                    {
                        queue.Enqueue(el.GetInteger());
                    }
                    else
                    {
                        Flatten(el.GetList());
                    }
                }
            }

            public bool HasNext()
            {
                return queue.Count > 0;
            }

            public int Next()
            {
                return queue.Dequeue();
            }
        }
    }
}
