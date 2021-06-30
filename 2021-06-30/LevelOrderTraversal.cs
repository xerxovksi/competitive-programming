namespace Google
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            int depth = Depth(root);
            IList<IList<int>> traversal = new List<IList<int>>();

            for (int i = 0; i < depth; i++)
            {
                traversal.Add(new List<int>());
            }

            Traverse(root, traversal, 0);
            return traversal;
        }

        private int Depth(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return Math.Max(
                1 + Depth(node.left),
                1 + Depth(node.right));
        }

        private void Traverse(TreeNode node, IList<IList> traversal, int level)
        {
            if (node == null)
            {
                return;
            }

            traversal[level].Add(node.val);

            Traverse(node.left, traversal, 1 + level);
            Traverse(node.right, traversal, 1 + level);
        }
    }
}