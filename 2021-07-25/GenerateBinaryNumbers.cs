namespace Google
{
    using System;
    using System.Collections.Generic;

    public class Node
    {
        public string val { get; set; }

        public Node next { get; set; }

        public Node(string val = null, Node next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Queue
    {
        Node head = null;

        Node current = null;

        public void Enqueue(string val)
        {
            if (head == null)
            {
                head = new Node(val);
                current = head;
            }
            else
            {
                current.next = new Node(val);
                current = current.next;
            }
        }

        public string Dequeue()
        {
            if (head == null)
            {
                throw new Exception("Queue is empty.");
            }

            string val = head.val;
            head = head.next;

            return val;
        }
    }

    public class Solution
    {
        private IList<string> GetBinaries(int n)
        {
            Queue queue = new Queue();
            queue.Enqueue("1");

            IList<string> binaries = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                string first = queue.Dequeue();
                binaries.Add(first);

                queue.Enqueue($"{first}0");
                queue.Enqueue($"{first}1");
            }

            return binaries;
        }
    }
}