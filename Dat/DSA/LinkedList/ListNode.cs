namespace DSA.LinkedList
{
    public class ListNode(int val = 0, ListNode? next = null)
    {
        public int Val = val;
        public ListNode? Next = next;

        public static ListNode? FromArray(int[] arr)
        {
            var dummy = new ListNode();
            var cur = dummy;

            foreach (var val in arr)
            {
                cur.Next = new ListNode(val, null);
                cur = cur.Next;
            }
            return dummy.Next;
        }

        public void Print()
        {
            var cur = this;
            while (cur != null)
            {
                Console.Write(cur.Val + " -> ");
                cur = cur.Next;
            }
        }
    }
}
