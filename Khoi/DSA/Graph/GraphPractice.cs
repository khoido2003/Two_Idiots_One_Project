namespace DSA.Graph
{
    public class GraphPractice
    {
        public static int RottenOrange(int[][] mat)
        {
            Queue<(int, int)> queue = new();
            (int, int)[] directions = [(0, -1), (-1, 0), (0, 1), (1, 0)];

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                    }
                }
            }

            bool flag = false;
            int cnt = 0;

            while (queue.Count > 0)
            {
                int len = queue.Count;

                flag = false;

                for (int i = 0; i < len; i++)
                {
                    var curNode = queue.Dequeue();

                    foreach (var el in directions)
                    {
                        (int, int) neighbor = (curNode.Item1 + el.Item1, curNode.Item2 + el.Item2);

                        int neighborX = neighbor.Item1;
                        int neighborY = neighbor.Item2;

                        if (
                            neighborX >= 0
                            && neighborY >= 0
                            && neighborX < mat.Length
                            && neighborY < mat[0].Length
                            && mat[neighborX][neighborY] == 1
                        )
                        {
                            queue.Enqueue((neighborX, neighborY));
                            mat[neighborX][neighborY] = 2;
                            flag = true;
                        }
                    }
                }

                if (flag)
                {
                    cnt++;
                }
            }

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 1)
                    {
                        return -1;
                    }
                }
            }

            return cnt;
        }
    }
}
