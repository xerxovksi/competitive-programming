namespace Google
{
    public class ListNode
    {
        public int val { get; set; }

        public ListNode next { get; set; }

        public ListNode(int val = null, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
            {
                return head;
            }

            ListNode current = head;
            while (current != null)
            {
                ListNode next = current.next;
                while (next != null)
                {
                    if (current.val == next.val)
                    {
                        next = next.next;
                    }
                    else
                    {
                        break;
                    }
                }

                current.next = next;
                current = current.next;
            }

            return head;
        }
    }
}