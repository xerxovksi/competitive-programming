namespace Google
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
        public ListNode MergeSortedLinkedLists(ListNode l1, ListNode l2)
        {
            ListNode result = null;
            ListNode resultHead = null;

            while (l1 != null || l2 != null)
            {
                ListNode small = null;
                if (l1 == null)
                {
                    small = new ListNode(l2.val);
                }
                else if (l2 == null)
                {
                    small = new ListNode(l1.val);
                }
                else
                {
                    small = l1.val < l2.val ? new ListNode(l1.val) : new ListNode(l2.val);
                }

                if (result == null)
                {
                    result = small;
                    resultHead = result;
                }
                else
                {
                    result.next = small;
                    result = result.next;
                }

                if (l1 != null && l1.val == small.val)
                {
                    l1 = l1.next;
                }
                else
                {
                    l2 = l2.next;
                }
            }

            return resultHead;
        }
    }
}