public class Test
{
    public struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public static void Solve_1(int[] arr)
    {
        int maxEven = int.MinValue;
        int minOdd = int.MaxValue;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0)
            {
                maxEven = Math.Max(arr[i], maxEven);
            }
            else
            {
                minOdd = Math.Min(arr[i], minOdd);
            }
        }

        Console.WriteLine("Min: " + minOdd + " - " + "Max: " + maxEven);
    }

    public static List<int> Solve_2(List<int> arr)
    {
        List<int> res = new();

        foreach (var el in arr)
        {
            if (el != 4)
            {
                res.Add(el);
            }
        }

        return res;
    }

    public static List<List<int>> Solve_3(List<int> arr)
    {
        List<List<int>> groupFound = new();
        int cur = arr[0];

        int j = 0;
        groupFound.Add([]);
        groupFound[0].Add(cur);

        for (int i = 1; i < arr.Count; i++)
        {
            if (cur < arr[i])
            {
                groupFound[j].Add(arr[i]);
            }
            else
            {
                groupFound.Add([]);

                j++;
                groupFound[j].Add(arr[i]);
            }

            cur = arr[i];
        }

        int max = int.MinValue;
        List<List<int>> res = new();

        foreach (var ls in groupFound)
        {
            max = Math.Max(ls.Count, max);
        }

        foreach (var ls in groupFound)
        {
            if (ls.Count == max)
            {
                res.Add(ls);
            }
        }

        return res;
    }

    private static double CalcLine(Vector2 a, Vector2 b)
    {
        return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
    }

    public static bool Solve_4_CheckPointsIsInLine(Vector2 point, Vector2 a, Vector2 b)
    {
        double aToPoint = CalcLine(a, point);
        double bToPoint = CalcLine(b, point);
        double aTob = CalcLine(a, b);

        return aToPoint + bToPoint == aTob;
    }

    public static void Main()
    {
        Console.WriteLine("Solve 1: ");
        int[] arr = [1, 5, 3, 7, 6, 8, 4, 8, 1, 0];
        Solve_1(arr);

        ///////////////////////////////////////////////
        Console.WriteLine("Solve 2: ");
        List<int> ls2 = [1, 2, 3, 4, 5, 4, 4, 6, 8, 9, 10];

        var res2 = Solve_2(ls2);

        foreach (var el in res2)
        {
            Console.Write(el + " ");
        }

        Console.WriteLine();

        ////////////////////////////////////////

        Console.WriteLine("Solve 3: ");

        List<int> ls3 = [1, 3, 5, 6, 7, 4, 4, 6, 8, 9, 10];

        var res3 = Solve_3(ls3);

        foreach (var ls in res3)
        {
            foreach (var el in ls)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }

        //////////////////////////////////////

        Console.WriteLine("Solve 4: ");
        var point = new Vector2(1, 1);
        var a = new Vector2(0, 2);
        var b = new Vector2(2, 0);

        var check = Solve_4_CheckPointsIsInLine(point, a, b);

        Console.WriteLine(check);
    }
}
