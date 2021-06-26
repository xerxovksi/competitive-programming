namespace Google
{
    using System.Collections.Generic;

    public class Node
    {
        public int val { get; set; }

        public Node left { get; set; }

        public Node right { get; set; }

        public Node(int val = 0, Node left = null, Node right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class BinarySearchTree
    {
        public Node AddNodes(int[] nums)
        {
            Node root = null;
            for (int i = 0; i < nums.Length; i++)
            {
                root = AddNode(root, nums[i]);
            }

            return root;
        }

        public List<int> PreOrder(Node root)
        {
            List<int> preOrder = new List<int>();
            Node current = root;
            PreOrder(current, preOrder);

            return preOrder;
        }

        private Node AddNode(Node root, int val)
        {
            if (root == null)
            {
                root = new Node(val);
                return root;
            }

            if (val > root.val)
            {
                root.right = AddNode(root.right, val);
                return root;
            }
            else
            {
                root.left = AddNode(root.left, val);
                return root;
            }
        }

        private void PreOrder(Node root, List<int> preOrder)
        {
            if (root == null)
            {
                return;
            }

            PreOrder(root.left, preOrder);
            preOrder.Add(root.val);
            PreOrder(root.right, preOrder);
        }
    }
}