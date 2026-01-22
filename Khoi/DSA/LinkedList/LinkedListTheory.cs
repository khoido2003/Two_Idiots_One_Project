// Insert

using System.Xml;

namespace DSA.LinkedList
{
    public class LinkedList
    {
        public class Node
        {
            public int data;
            public Node next = null;

            public Node(int data)
            {
                this.data = data;
                next = null;
            }
        }

        public static Node InsertToEnd(Node root, int d)
        {
            Node newNode = new(d);

            if (root == null)
            {
                return newNode;
            }

            Node last = root;
            while (last.next != null)
            {
                last = last.next;
            }
            last.next = newNode;

            return root;
        }

        public static Node InsertToFist(Node root, int d)
        {
            Node newNode = new Node(d);

            if (root == null)
            {
                return newNode;
            }

            newNode.next = root;

            root = newNode;

            return root;
        }

        public static void DeleteAtEnd(Node root)
        {
            Node curNode = root;
            while (curNode.next.next != null)
            {
                curNode = curNode.next;
            }

            curNode.next = null;
        }

        public static void DeleteAtPosition(Node root, int key)
        {
            Node curNode = root;
            Node prevNode = null;

            if (curNode != null && curNode.data == key)
            {
                root = curNode.next;
                return;
            }

            while (curNode != null && curNode.data != key)
            {
                prevNode = curNode;
                curNode = curNode.next;
            }

            if (curNode == null)
            {
                return;
            }

            prevNode.next = curNode.next;
        }

        public static Node CreateFromArray(int[] arr)
        {
            Node root = null;
            for (int i = 0; i < arr.Length; i++)
            {
                root = InsertToEnd(root, arr[i]);
            }

            return root;
        }

        public static void PrintList(Node head)
        {
            Node curNode = head;

            while (curNode.next != null)
            {
                Console.WriteLine(curNode.data);
                curNode = curNode.next;
            }
            Console.WriteLine(curNode);
        }
    }
}
