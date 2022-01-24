namespace Practice
{
    public class ListNode
    {
        public int val { get; set; }

        public ListNode next { get; set; }

        public ListNode(int val, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode RemoveNthFromLinkedListEnd(ListNode head, int n)
        {
            int count = 0;
            ListNode curr = head;

            while (curr != null)
            {
                count++;
                curr = curr.next;
            }

            if (n == count)
            {
                head = head.next;
                return head;
            }

            int i = 0;
            int indexToRemove = count - n;
            curr = head;

            while (curr != null)
            {
                if (i == indexToRemove - 1)
                {
                    curr.next = curr.next.next;
                    curr = curr.next;

                    i = i + 2;
                }
                else
                {
                    curr = curr.next;
                    i++;
                }
            }

            return head;
        }
    }
}