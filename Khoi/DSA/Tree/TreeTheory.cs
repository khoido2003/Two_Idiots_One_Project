namespace DSA.Tree
{
    public class Node
    {
        public int data;
        public List<Node> children;

        public Node(int v)
        {
            data = v;
            children = new List<Node>();
        }
    }

    public class BinaryNode
    {
        public int data;
        public BinaryNode left;
        public BinaryNode right;

        public BinaryNode(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }

    public class TreeTheory
    {
        public static BinaryNode BuildTree(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return null;
            }

            BinaryNode node = new(nums[0]);

            Queue<BinaryNode> queue = new();
            queue.Enqueue(node);

            int i = 1;
            while (i < nums.Length)
            {
                BinaryNode curNode = queue.Dequeue();

                if (i < nums.Length)
                {
                    curNode.left = new BinaryNode(nums[i]);
                    i++;

                    queue.Enqueue(curNode.left);
                }

                if (i < nums.Length)
                {
                    curNode.right = new BinaryNode(nums[i]);
                    i++;
                    queue.Enqueue(curNode.right);
                }
            }

            return node;
        }

        public static int GetLevelOfNode(int v) { }

        public static int FindTreeHeight(BinaryNode root)
        {
            Queue<BinaryNode> queue = new();

            queue.Enqueue(root);

            int height = 0;

            while (queue.Count > 0)
            {
                int len = queue.Count;

                for (int i = 0; i < len; i++)
                {
                    BinaryNode curNode = queue.Dequeue();

                    if (curNode.left != null)
                    {
                        queue.Enqueue(curNode.left);
                    }

                    if (curNode.right != null)
                    {
                        queue.Enqueue(curNode.right);
                    }
                }

                height++;
            }

            return height - 1;
        }

        public static void PrintTreeLevelOrder(BinaryNode root)
        {
            Queue<BinaryNode> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int len = queue.Count;

                for (int i = 0; i < len; i++)
                {
                    var curNode = queue.Dequeue();
                    Console.Write(curNode.data + " ");

                    if (curNode.left != null)
                    {
                        queue.Enqueue(curNode.left);
                    }

                    if (curNode.right != null)
                    {
                        queue.Enqueue(curNode.right);
                    }
                }

                Console.WriteLine();
            }
        }

        public static void PrintTree(BinaryNode root)
        {
            if (root == null)
            {
                return;
            }

            PrintTree(root.left);
            Console.Write(root.data + " ");
            PrintTree(root.right);
        }

        public static void AddChild(Node parent, Node child)
        {
            parent.children.Add(child);
        }

        public static void PrintParents(Node node, Node parent)
        {
            if (parent == null)
            {
                Console.WriteLine(node.data + " -> NULL");
            }
            else
            {
                Console.WriteLine(node.data + " -> " + parent.data);
            }

            foreach (var child in node.children)
            {
                PrintParents(child, node);
            }
        }

        public static void PrintChildren(Node node)
        {
            Console.WriteLine(node.data + " -> ");

            foreach (var child in node.children)
            {
                Console.Write(child.data + " ");
            }

            Console.WriteLine();

            foreach (var child in node.children)
            {
                PrintChildren(child);
            }
        }
    }
}
