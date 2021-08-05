namespace Google
{
    using System.Collections.Generic;

    public class TreeNode
    {
        public int val { get; set; }

        public TreeNode left { get; set; }

        public TreeNode right { get; set; }

        public TreeNode(int val = 0, TreeNode left, TreeNode right)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public IList<int> RightSideView(TreeNode root)
        {
            IList<int> result = new List<int>();
            RightSideView(root, 0, result);

            return result;
        }

        private void RightSideView(TreeNode node, int level, IList<int> result)
        {
            if (node == null)
            {
                return;
            }

            if (level >= result.Count)
            {
                result.Add(node.val);
            }

            RightSideView(node.right, level + 1, result);
            RightSideView(node.left, level + 1, result);
        }
    }
}