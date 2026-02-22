using System.Text;

namespace DSA.Greedy
{
    public class GreedyTheory
    {
        public static int AssignMousesToHoles(int[] mices, int[] holes)
        {
            Array.Sort(mices);
            Array.Sort(holes);

            int max = int.MinValue;
            for (int i = 0; i < mices.Length; i++)
            {
                max = Math.Max(Math.Abs(mices[i] - holes[i]), max);
            }
            return max;
        }

        ////////////////////////////////////////////////////////

        public static (int, int, int) FittingShelves(int w, int m, int n)
        {
            int big = 0;
            int small = 0;
            bool isSwapped = false;

            if (m >= n)
            {
                big = m;
                small = n;
            }
            else
            {
                big = n;
                small = m;
                isSwapped = true;
            }

            int bestEmpty = int.MaxValue;
            int bestBig = 0;
            int bestSmall = 0;

            int maxAmountBig = w / big;

            for (int i = maxAmountBig; i >= 0; i--)
            {
                int remainSpace = w - big * i;

                int maxAmountSmall = remainSpace / small;

                remainSpace -= maxAmountSmall * small;

                if (remainSpace < bestEmpty)
                {
                    bestEmpty = remainSpace;
                    bestBig = i;
                    bestSmall = maxAmountSmall;
                }
            }

            if (isSwapped)
            {
                return (bestSmall, bestBig, bestEmpty);
            }
            return (bestBig, bestSmall, bestEmpty);
        }

        //////////////////////////////////////////////////////////////

        public static int PoliceCatchThieves(char[] arr, int k)
        {
            Queue<int> polices = new();
            Queue<int> thieves = new();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 'P')
                {
                    polices.Enqueue(i);
                }
                else
                {
                    thieves.Enqueue(i);
                }
            }

            int cnt = 0;
            while (polices.Count > 0 && thieves.Count > 0)
            {
                if (Math.Abs(polices.Peek() - thieves.Peek()) <= k)
                {
                    cnt++;
                    polices.Dequeue();
                    thieves.Dequeue();
                }
                else if (polices.Peek() < thieves.Peek())
                {
                    polices.Dequeue();
                }
                else
                {
                    thieves.Dequeue();
                }
            }
            return cnt;
        }

        /////////////////////////////////////////////////////////////////

        public static void PrintEgyptian(int numerator, int denominator)
        {
            if (denominator == 0 || numerator == 0)
            {
                return;
            }

            if (denominator % numerator == 0)
            {
                Console.Write("1/" + denominator / numerator);
                return;
            }

            if (numerator % denominator == 0)
            {
                Console.Write(numerator / denominator);
                return;
            }

            if (numerator > denominator)
            {
                Console.Write(numerator / denominator + " + ");
                PrintEgyptian(numerator % denominator, denominator);
                return;
            }

            int n = denominator / numerator + 1;
            Console.Write("1/" + n + " + ");

            PrintEgyptian(numerator * n - denominator, denominator * n);
        }

        //////////////////////////////////////////////

        public static int SwapCount(string s)
        {
            char[] chars = s.ToCharArray();

            int countLeft = 0;
            int countRight = 0;

            int imbalance = 0;
            int swap = 0;

            foreach (char c in chars)
            {
                if (c == '[')
                {
                    countLeft++;

                    if (imbalance > 0)
                    {
                        swap += imbalance;
                        imbalance--;
                    }
                }
                else if (c == ']')
                {
                    countRight++;

                    imbalance = countRight - countLeft;
                }
            }
            return swap;
        }

        /////////////////////////////////////////////////////////////

        public static List<List<int>> FindWaterDistribution(int n, int p, int[] a, int[] b, int[] d)
        {
            int[] outPipe = new int[n + 1];
            int[] inPipe = new int[n + 1];
            int[] minDiameter = new int[n + 1];

            for (int i = 0; i < a.Length; i++)
            {
                outPipe[a[i]] = b[i];
                inPipe[b[i]] = a[i];
                minDiameter[a[i]] = d[i];
            }

            int tank = -1;
            int tap = -1;
            int minD = int.MaxValue;
            int currentHouse = -1;

            List<List<int>> res = new();

            for (int i = 0; i < n; i++)
            {
                if (outPipe[i] != 0 && inPipe[i] == 0)
                {
                    tank = i;
                    currentHouse = i;
                    minD = int.MaxValue;

                    while (outPipe[currentHouse] != 0)
                    {
                        minD = Math.Min(minD, minDiameter[currentHouse]);
                        currentHouse = outPipe[currentHouse];
                    }

                    tap = currentHouse;
                    res.Add([tank, tap, minD]);
                }
            }

            return res;
        }

        ////////////////////////////////////////////////////////////////

        // Huffman

        public class Node
        {
            public int data;
            public Node left,
                right;
            public char character;

            public Node(int x, char c)
            {
                data = x;
                left = null;
                right = null;
                character = c;
            }
        }

        private static void PreOrder(Node curNode, List<string> ans, string curr)
        {
            if (curNode == null)
            {
                return;
            }

            if (curNode.left == null && curNode.right == null)
            {
                ans.Add(curr);
                return;
            }

            PreOrder(curNode.left, ans, curr + "0");
            PreOrder(curNode.right, ans, curr + "1");
        }

        public static void BuildMap(Node node, string curr, Dictionary<char, string> map)
        {
            if (node == null)
                return;

            if (node.left == null && node.right == null)
            {
                map[node.character] = curr;
                return;
            }

            BuildMap(node.left, curr + "0", map);
            BuildMap(node.right, curr + "1", map);
        }

        public static string DecodeHuffman(Node root, string encoded)
        {
            StringBuilder result = new();

            Node current = root;

            foreach (char bit in encoded)
            {
                if (bit == '0')
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }

                if (current.left == null && current.right == null)
                {
                    result.Append(current.character);
                    current = root;
                }
            }

            return result.ToString();
        }

        public static List<string> HuffmanCode(string s, int[] freq, out Node root)
        {
            PriorityQueue<Node, int> pq = new();
            int n = s.Length;

            for (int i = 0; i < freq.Length; i++)
            {
                Node newNode = new(freq[i], s[i]);
                pq.Enqueue(newNode, freq[i]);
            }

            while (pq.Count > 1)
            {
                Node node1 = pq.Dequeue();
                Node node2 = pq.Dequeue();

                Node newNode = new(node1.data + node2.data, '*');

                newNode.left = node1;
                newNode.right = node2;

                pq.Enqueue(newNode, newNode.data);
            }

            root = pq.Dequeue();
            List<string> res = new();
            PreOrder(root, res, "");

            return res;
        }

        ////////////////////////////////////////////////

        public static List<int> JobSequencing(int[] deadline, int[] profit)
        {
            List<(int d, int p)> jobsList = new();
            PriorityQueue<(int, int), int> pq = new();

            for (int i = 0; i < deadline.Length; i++)
            {
                jobsList.Add((deadline[i], profit[i]));
            }

            jobsList.Sort((a, b) => a.d.CompareTo(b.d));

            foreach (var job in jobsList)
            {
                if (pq.Count < job.d)
                {
                    pq.Enqueue((job.d, job.p), job.p);
                }
                else if (pq.Count > 0 && pq.Peek().Item2 < job.p)
                {
                    pq.Dequeue();
                    pq.Enqueue((job.d, job.p), job.p);
                }
            }

            int totalJobs = pq.Count;
            int totalProfit = 0;
            while (pq.Count > 0)
            {
                (int curDeadline, int curProfit) = pq.Dequeue();

                totalProfit += curProfit;
            }

            return new List<int> { totalJobs, totalProfit };
        }

        //////////////////////////////////////////////////

        public static int MaxEqualSumOfThreeStack(int[] s1, int[] s2, int[] s3)
        {
            int sum1 = 0,
                sum2 = 0,
                sum3 = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                sum1 += s1[i];
            }

            for (int i = 0; i < s2.Length; i++)
            {
                sum2 += s2[i];
            }

            for (int i = 0; i < s3.Length; i++)
            {
                sum3 += s3[i];
            }

            int i1 = 0,
                i2 = 0,
                i3 = 0;

            while (true)
            {
                if (i1 == s1.Length || i2 == s2.Length || i3 == s3.Length)
                {
                    return 0;
                }

                if (sum1 == sum2 && sum2 == sum3)
                {
                    return sum1;
                }

                if (sum1 > sum2 && sum1 > sum3)
                {
                    sum1 -= s1[i1];
                    i1++;
                }
                else if (sum2 > sum1 && sum2 > sum3)
                {
                    sum2 -= s2[i2];
                    i2++;
                }
                else
                {
                    sum3 -= s3[i3];
                    i3++;
                }
            }
        }

        ////////////////////////////////////////////////////////

        public static Dictionary<int, int> FindMinNumOfCurrencyNotes(int input)
        {
            int[] notes = new int[9] { 2000, 500, 200, 100, 50, 20, 10, 5, 1 };

            Dictionary<int, int> map = new();

            PriorityQueue<int, int> pq = new();
            for (int i = 0; i < notes.Length; i++)
            {
                pq.Enqueue(notes[i], -notes[i]);
            }

            while (input > 0 && pq.Count > 0)
            {
                var note = pq.Dequeue();

                if (note > input)
                {
                    continue;
                }

                int amount = 0;

                while (note <= input)
                {
                    amount++;
                    input -= note;
                }

                if (amount > 0)
                {
                    map[note] = amount;
                }
            }

            return map;
        }

        //////////////////////////////////////////////////////////

        public static List<int> MinMaxCandy(int[] prices, int k)
        {
            Array.Sort(prices);

            int n = prices.Length;

            List<int> res = new(2);
            int minSum = 0;
            int maxSum = 0;

            int minCurCandyFree = 0;
            int maxCurCandyFree = 0;

            for (int i = 0; i < n; i++)
            {
                minSum += prices[i];

                minCurCandyFree += k + 1;

                if (minCurCandyFree >= n)
                {
                    break;
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                maxSum += prices[i];

                maxCurCandyFree += k + 1;

                if (maxCurCandyFree >= n)
                {
                    break;
                }
            }

            res.Add(minSum);
            res.Add(maxSum);

            return res;
        }

        ////////////////////////////////////////////////////

        public static int MaxSumConsecutiveDifferences(int[] arr, int n)
        {
            int sum = 0;
            Array.Sort(arr);

            for (int i = 0; i < n / 2; i++)
            {
                sum -= 2 * arr[i];
                sum += 2 * arr[n - i - 1];
            }

            return sum;
        }

        ///////////////////////////////////////////////////////

        public static int MaxStocks(int[] price, int k)
        {
            PriorityQueue<(int, int), int> pq = new();

            for (int i = 0; i < price.Length; i++)
            {
                pq.Enqueue((price[i], i + 1), price[i]);
            }

            int res = 0;

            while (pq.Count > 0)
            {
                (int curPrice, int curDay) = pq.Dequeue();

                int maxCanBuy = Math.Min(k / curPrice, curDay);
                res += maxCanBuy;
                k -= maxCanBuy * curPrice;

                if (k == 0)
                {
                    break;
                }
            }

            return res;
        }

        //////////////////////////////////////////////////////

        public static int MaxCookies(int[] greed, int[] cookie)
        {
            Array.Sort(greed);
            Array.Sort(cookie);

            int i = 0,
                j = 0;
            int cnt = 0;
            while (i < greed.Length && j < cookie.Length)
            {
                if (greed[i] <= cookie[j])
                {
                    cnt++;
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }

            return cnt;
        }

        //////////////////////////////////////////////////

        private static int Patition(int[] arr, int l, int r)
        {
            int pivot = arr[r];

            int i = l - 1;
            for (int j = l; j < r; j++)
            {
                if (arr[j] < pivot)
                {
                    int tmp1 = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp1;

                    i++;
                }
            }

            int tmp = arr[r];
            arr[r] = arr[i + 1];
            arr[i + 1] = tmp;

            return i + 1;
        }

        private static void QuickSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int p = Patition(arr, l, r);

                QuickSort(arr, l, p - 1);
                QuickSort(arr, p + 1, r);
            }
        }

        public static int MinElements(int[] arr, int n)
        {
            int halfSum = 0;

            for (int i = 0; i < n; i++)
            {
                halfSum += arr[i];
            }

            halfSum /= 2;

            QuickSort(arr, 0, arr.Length - 1);

            int res = 0;
            int curSum = 0;

            for (int i = n - 1; i >= 0; i--)
            {
                res++;

                curSum += arr[i];
                if (curSum > halfSum)
                {
                    return res;
                }
            }

            return res;
        }

        ////////////////////////////////////////////////////////////////////

        public static int MinRotation(int input, int unlockCode)
        {
            int rotation = 0;
            int inputDigit,
                unlockDigit;

            while (input > 0 || unlockCode > 0)
            {
                inputDigit = input % 10;
                unlockDigit = unlockCode % 10;

                rotation += Math.Min(
                    Math.Abs(inputDigit - unlockDigit),
                    10 - Math.Abs(inputDigit - unlockDigit)
                );

                input /= 10;
                unlockCode /= 10;
            }

            return rotation;
        }

        /////////////////////////////////////////////////////////////////////////

        public static double FractionalKnapsack(int[] val, int[] wt, int capacity)
        {
            PriorityQueue<(int, int), double> pq = new();

            for (int i = 0; i < val.Length; i++)
            {
                int valEl = val[i];
                int wtEl = wt[i];

                double ratio = (double)valEl / wtEl;

                pq.Enqueue((valEl, wtEl), -ratio);
            }

            int currentCapacity = capacity;
            double res = 0;

            while (pq.Count > 0)
            {
                (int curVal, int curWt) = pq.Dequeue();

                if (curWt <= currentCapacity)
                {
                    res += curVal;
                    currentCapacity -= curWt;
                }
                else if (curWt > currentCapacity)
                {
                    res += (double)curVal / curWt * currentCapacity;
                    break;
                }
            }

            return res;
        }

        public static int CostReducedToOne(int[] a)
        {
            int n = a.Length;
            int min = a.Min();

            return (n - 1) * min;
        }
    }
}
