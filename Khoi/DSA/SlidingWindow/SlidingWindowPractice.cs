using System.Text;

namespace DSA.SlidingWindow
{
    public class SlidingWindowPractice
    {
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            if (arr.Length == k)
            {
                return new List<int>(arr);
            }

            int left = 0;
            int right = arr.Length - 1;

            while (right - left + 1 > k)
            {
                if (x - arr[left] > arr[right] - x)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            IList<int> res = new List<int>();

            for (int i = left; i <= right; i++)
            {
                res.Add(arr[i]);
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/longest-repeating-character-replacement/description/?envType=problem-list-v2&envId=sliding-window

        public int CharacterReplacement(string s, int k)
        {
            char[] chars = s.ToCharArray();

            int[] freq = new int[26];

            int left = 0;
            int maxFreq = 0;
            int maxLen = 0;

            for (int right = 0; right < chars.Length; right++)
            {
                int index = chars[right] - 'A';
                freq[index] += 1;

                maxFreq = Math.Max(maxFreq, freq[index]);

                while ((right - left + 1) - maxFreq > k)
                {
                    freq[chars[left] - 'A'] -= 1;
                    left += 1;
                }

                maxLen = Math.Max(maxLen, right - left + 1);
            }

            return maxLen;
        }

        ////////////////////////////////////////////////
        // https://leetcode.com/problems/arithmetic-slices/submissions/1953805189/?envType=problem-list-v2&envId=sliding-window
        public int NumberOfArithmeticSlices(int[] nums)
        {
            if (nums.Length < 3)
            {
                return 0;
            }

            int current = 0;
            int total = 0;

            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i - 2] - nums[i - 1] == nums[i - 1] - nums[i])
                {
                    current++;

                    total += current;
                }
                else
                {
                    current = 0;
                }
            }

            return total;
        }

        /////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/contains-duplicate-ii/?envType=problem-list-v2&envId=sliding-window

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, (bool, int, int)> map = new();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map[nums[i]] = (false, i, i);
                }
                else
                {
                    (bool check, int prevPos, int curDistance) = map[nums[i]];

                    int minDistance = Math.Min(curDistance, i - prevPos);

                    if (!check)
                    {
                        minDistance = i - prevPos;
                    }

                    map[nums[i]] = (true, i, minDistance);
                }
            }

            foreach (var (key, (check, pos, distance)) in map)
            {
                if (check && distance <= k)
                {
                    return true;
                }
            }

            return false;
        }

        //////////////////////////////////////////////////////////////////////////
        // https://leetcode.com/problems/repeated-dna-sequences/submissions/1953698376/?envType=problem-list-v2&envId=sliding-window
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            if (s.Length < 10)
            {
                return new List<string>();
            }

            int k = 10;

            char[] chars = s.ToCharArray();

            StringBuilder curDna = new("");

            Dictionary<string, int> map = new();

            for (int i = 0; i < k; i++)
            {
                curDna.Append(chars[i]);
            }

            map[curDna.ToString()] = 1;

            for (int i = k; i < chars.Length; i++)
            {
                curDna.Remove(0, 1);
                curDna.Append(chars[i]);

                if (map.ContainsKey(curDna.ToString()))
                {
                    map[curDna.ToString()]++;
                }
                else
                {
                    map[curDna.ToString()] = 1;
                }
            }

            IList<string> res = new List<string>();

            foreach (var (key, value) in map)
            {
                if (value > 1)
                {
                    res.Add(key.ToString());
                }
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////////

        // https://leetcode.com/problems/longest-substring-without-repeating-characters/description/?envType=problem-list-v2&envId=sliding-window

        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, bool> map = new();
            char[] chars = s.ToCharArray();

            if (chars.Length == 0)
            {
                return 0;
            }

            foreach (char el in chars)
            {
                if (!map.ContainsKey(el))
                {
                    map[el] = false;
                }
            }

            if (map.Count == 1)
            {
                return 1;
            }

            int j = 0;
            int cnt = 0;
            int max = int.MinValue;
            for (int i = 0; i < chars.Length; i++)
            {
                while (map[chars[i]])
                {
                    map[chars[j]] = false;
                    j++;
                    cnt--;
                }

                map[chars[i]] = true;
                cnt++;

                if (cnt > max)
                {
                    max = cnt;
                }
            }

            return max;
        }
    }
}
