namespace Google
{
    using System.Collections.Generic;

    public class TreeNode
    {
        public int val { get; set; }

        public TreeNode left { get; set; }

        public TreeNode right { get; set; }

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public IList InOrderTraversal(TreeNode node)
        {
            IList<int> result = new List<int>();
            InOrderTraversal(node, result);

            return result;
        }

        private void InOrderTraversal(TreeNode node, IList<int> result)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.left, result);
            result.Add(node.val);
            InOrderTraversal(node.right, result);
        }
    }
}