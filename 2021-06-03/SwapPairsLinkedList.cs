namespace Practice
{
    public class ListNode
    {
        public int val { get; set; }
        public ListNode next { get; set; }

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode SwapPairs(ListNode head)
        {
            ListNode curr = head;
            while (curr != null && curr.next != null)
            {
                int temp = curr.val;
                curr.val = curr.next.val;
                curr.next.val = temp;

                curr = curr.next.next;
            }

            return head;
        }
    }
}