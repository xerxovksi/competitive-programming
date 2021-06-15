namespace Google
{
    using System.Collections.Generic;

    public class Node
    {
        public int val { get; set; }

        public Node next { get; set; }

        public Node random { get; set; }

        public Node(int val = 0, Node next = null, Node random = null)
        {
            this.val = val;
            this.next = next;
            this.random = random;
        }
    }

    public class Solution
    {
        public Node CopyRandomList(Node head)
        {
            Node curr = head;

            Node newHead = null;
            Node newCurr = null;
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();

            while (curr != null)
            {
                if (newHead == null)
                {
                    newHead = new Node(curr.val);
                    map.Add(curr, newHead);

                    newCurr = newHead;
                    curr = curr.next;
                    continue;
                }

                newCurr.next = new Node(curr.val);
                map.Add(curr, newCurr.next);

                newCurr = newCurr.next;
                curr = curr.next;
            }

            curr = head;
            newCurr = newHead;

            while (curr != null)
            {
                newCurr.random = curr.random != null ? map[curr.random] : null;

                newCurr = newCurr.next;
                curr = curr.next;
            }

            return newHead;
        }
    }
}