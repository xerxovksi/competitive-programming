namespace Practice
{
    using System;

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var left = 1 + MinDepth(root.left);
            var right = 1 + MinDepth(root.right);

            if (left == 1)
            {
                return right;
            }

            if (right == 1)
            {
                return left;
            }

            return Math.Min(left, right);
        }
    }
}