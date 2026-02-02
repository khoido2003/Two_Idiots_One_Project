using System.Runtime.CompilerServices;

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
        public static BinaryNode BuildBSTTree(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return null;
            }

            BinaryNode root = new(arr[0]);

            for (int i = 1; i < arr.Length; i++)
            {
                InsertBSTTree(root, arr[i]);
            }

            return root;
        }

        public static BinaryNode DeleteNodeBST(BinaryNode root, int v)
        {
            if (root == null)
            {
                return root;
            }

            if (root.data > v)
            {
                root.left = DeleteNodeBST(root.left, v);
            }
            else if (root.data < v)
            {
                root.right = DeleteNodeBST(root.right, v);
            }
            else
            {
                if (root.left == null)
                {
                    return root.right;
                }
                if (root.right == null)
                {
                    return root.left;
                }

                BinaryNode succ = GetSuccessorBSTNode(root);
                root.data = succ.data;
                DeleteNodeBST(root.right, succ.data);
            }

            return root;
        }

        private static BinaryNode GetSuccessorBSTNode(BinaryNode cur)
        {
            cur = cur.right;

            while (cur != null && cur.left != null)
            {
                cur = cur.left;
            }

            return cur;
        }

        private static void InsertBSTTree(BinaryNode root, int v)
        {
            BinaryNode cur = root;

            while (true)
            {
                if (cur.data > v)
                {
                    if (cur.left == null)
                    {
                        cur.left = new BinaryNode(v);
                        return;
                    }
                    else
                    {
                        cur = cur.left;
                    }
                }

                if (cur.data < v)
                {
                    if (cur.right == null)
                    {
                        cur.right = new BinaryNode(v);
                        return;
                    }
                    else
                    {
                        cur = cur.right;
                    }
                }

                if (cur.data == v)
                {
                    return;
                }
            }
        }

        public static bool SearchBstTree(BinaryNode root, int key)
        {
            if (root == null)
            {
                return false;
            }

            if (root.data == key)
            {
                return true;
            }

            if (root.data < key)
            {
                return SearchBstTree(root.right, key);
            }

            return SearchBstTree(root.left, key);
        }

        ////////////////////////////////////////////////////////////////////

        public static BinaryNode BuildBinaryTree(int[] nums)
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

        public static void DeleteDeepest(BinaryNode root, BinaryNode dNode)
        {
            Queue<BinaryNode> queue = new();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int len = queue.Count;

                for (int i = 0; i < len; i++)
                {
                    BinaryNode curNode = queue.Dequeue();

                    if (curNode == dNode)
                    {
                        dNode = null;
                        curNode = null;

                        return;
                    }

                    if (curNode.left != null)
                    {
                        if (curNode.left == dNode)
                        {
                            curNode.left = null;
                            return;
                        }
                        queue.Enqueue(curNode.left);
                    }

                    if (curNode.right != null)
                    {
                        if (curNode.right == dNode)
                        {
                            curNode.right = null;
                            return;
                        }
                        queue.Enqueue(curNode.right);
                    }
                }
            }
        }

        public static BinaryNode DeleteNode(BinaryNode root, int key)
        {
            Queue<BinaryNode> queue = new();

            queue.Enqueue(root);

            BinaryNode delNode = null;
            BinaryNode curNode = null;

            while (queue.Count > 0)
            {
                int len = queue.Count;

                for (int i = 0; i < len; i++)
                {
                    curNode = queue.Dequeue();

                    if (curNode.data == key)
                    {
                        delNode = curNode;
                    }

                    if (curNode.left != null)
                    {
                        queue.Enqueue(curNode.left);
                    }

                    if (curNode.right != null)
                    {
                        queue.Enqueue(curNode.right);
                    }
                }
            }

            if (delNode != null)
            {
                delNode.data = curNode.data;

                DeleteDeepest(root, curNode);
            }

            return root;
        }

        public static BinaryNode InsertNode(BinaryNode root, int v)
        {
            if (root == null)
            {
                BinaryNode newNode = new(v);

                return newNode;
            }

            Queue<BinaryNode> queue = new();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int len = queue.Count;

                for (int i = 0; i < len; i++)
                {
                    BinaryNode curNode = queue.Dequeue();

                    if (curNode.left == null)
                    {
                        BinaryNode newNode = new(v);
                        curNode.left = newNode;
                        return root;
                    }
                    else
                    {
                        queue.Enqueue(curNode.left);
                    }

                    if (curNode.right == null)
                    {
                        BinaryNode newNode = new(v);
                        curNode.right = newNode;
                        return root;
                    }
                    else
                    {
                        queue.Enqueue(curNode.right);
                    }
                }
            }

            return root;
        }

        public static int GetParentOfNode(BinaryNode root, int key)
        {
            Dictionary<BinaryNode, BinaryNode> map = new();

            if (root == null)
            {
                return -1;
            }

            map[root] = null;

            Queue<BinaryNode> queue = new();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int len = queue.Count;

                for (int i = 0; i < len; i++)
                {
                    BinaryNode curNode = queue.Dequeue();

                    if (curNode.data == key)
                    {
                        return map[curNode].data;
                    }

                    if (curNode.left != null)
                    {
                        map[curNode.left] = curNode;
                        queue.Enqueue(curNode.left);
                    }

                    if (curNode.right != null)
                    {
                        map[curNode.right] = curNode;
                        queue.Enqueue(curNode.right);
                    }
                }
            }

            return -1;
        }

        public static int GetLevelOfNode(BinaryNode root, int v)
        {
            if (root == null)
            {
                return -1;
            }

            Queue<BinaryNode> queue = new();
            queue.Enqueue(root);

            int cnt = 1;

            while (queue.Count > 0)
            {
                int len = queue.Count;

                for (int i = 0; i < len; i++)
                {
                    BinaryNode curNode = queue.Dequeue();

                    if (curNode.data == v)
                    {
                        return cnt;
                    }

                    if (curNode.left != null)
                    {
                        queue.Enqueue(curNode.left);
                    }

                    if (curNode.right != null)
                    {
                        queue.Enqueue(curNode.right);
                    }
                }

                cnt++;
            }

            return -1;
        }

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
