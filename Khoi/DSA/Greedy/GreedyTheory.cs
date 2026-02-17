namespace DSA.Greedy
{
    public class GreedyTheory
    {
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
