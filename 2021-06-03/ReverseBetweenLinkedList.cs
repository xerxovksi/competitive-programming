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
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            var leftHead = GetLeft(head, left);
            var rightHead = GetRight(head, right);
            var centerHead = GetReversedCenter(head, left, right);

            return GetCombined(leftHead, centerHead, rightHead);
        }

        private ListNode GetLeft(ListNode head, int left)
        {
            ListNode leftHead = null;
            ListNode leftStart = null;
            int index = 1;

            while (head != null)
            {
                if (index == left)
                {
                    break;
                }

                if (leftHead == null)
                {
                    leftHead = new ListNode(head.val);
                    leftStart = leftHead;
                    head = head.next;

                    index++;
                    continue;
                }

                leftHead.next = new ListNode(head.val);
                leftHead = leftHead.next;
                head = head.next;

                index++;
            }

            leftHead = leftStart;
            return leftHead;
        }

        private ListNode GetRight(ListNode head, int right)
        {
            ListNode rightHead = null;
            ListNode rightStart = null;
            int index = 1;

            while (head != null)
            {
                if (index <= right)
                {
                    head = head.next;
                    index++;
                    continue;
                }

                if (rightHead == null)
                {
                    rightHead = new ListNode(head.val);
                    rightStart = rightHead;
                    head = head.next;

                    index++;
                    continue;
                }

                rightHead.next = new ListNode(head.val);
                rightHead = rightHead.next;
                head = head.next;

                index++;
            }

            rightHead = rightStart;
            return rightHead;
        }

        private ListNode GetReversedCenter(ListNode head, int left, int right)
        {
            ListNode centerHead = null;
            ListNode centerStart = null;
            int index = 1;

            while (head != null)
            {
                if (index < left)
                {
                    head = head.next;
                    index++;
                    continue;
                }

                if (centerHead == null)
                {
                    centerHead = new ListNode(head.val);
                    centerStart = centerHead;
                    head = head.next;

                    index++;
                    continue;
                }

                if (index == right)
                {
                    centerHead.next = new ListNode(head.val);
                    break;
                }

                if (index > right)
                {
                    break;
                }

                centerHead.next = new ListNode(head.val);
                centerHead = centerHead.next;
                head = head.next;

                index++;
            }

            centerHead = centerStart;
            return GetReversed(centerHead);
        }

        private ListNode GetReversed(ListNode head)
        {
            ListNode curr = head;
            ListNode prev = null;
            ListNode next = null;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;

                prev = curr;
                curr = next;
            }

            curr = prev;
            return curr;
        }

        private ListNode GetCombined(ListNode leftHead, ListNode centerHead, ListNode rightHead)
        {
            var result = Combine(leftHead, centerHead);
            result = Combine(result, rightHead);

            return result;
        }

        private ListNode Combine(ListNode left, ListNode right)
        {
            ListNode leftStart = left;

            if (left != null)
            {
                while (left.next != null)
                {
                    left = left.next;
                }
            }

            while (right != null)
            {
                if (left == null)
                {
                    left = new ListNode(right.val);
                    leftStart = left;
                    right = right.next;
                    continue;
                }

                left.next = new ListNode(right.val);
                left = left.next;
                right = right.next;
            }

            left = leftStart;
            return left;
        }
    }
}