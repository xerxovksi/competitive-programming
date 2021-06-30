namespace Google
{
    using System;
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
        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            int depth = Depth(root);

            Dictionary<int, TreeNode> parents = new Dictionary<int, TreeNode>();
            Parents(root, parents);

            IList<int> result = new List<int>();
            HashSet<int> seen = new HashSet<int>();
            Traverse(target, result, seen, 0, k);

            TreeNode curr;
            if (!parents.ContainsKey(target.val))
            {
                return result;
            }

            curr = parents[target.val];
            int i = 1;
            while (i <= k)
            {
                if (curr == null)
                {
                    return result;
                }

                Traverse(curr, result, seen, i, k);
                if (!parents.ContainsKey(curr.val))
                {
                    return result;
                }

                curr = parents[curr.val];
                i++;
            }

            return result;
        }

        private int Depth(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return Math.Max(
                1 + Depth(node.left),
                1 + Depth(node.right)
            );
        }

        private void Parents(TreeNode node, Dictionary<int, TreeNode> parents)
        {
            if (node == null)
            {
                return;
            }

            if (node.left != null)
            {
                parents.Add(node.left.val, node);
            }

            if (node.right != null)
            {
                parents.Add(node.right.val, node);
            }

            Parents(node.left, parents);
            Parents(node.right, parents);
        }

        private void Traverse(
            TreeNode node,
            IList<int> result,
            HashSet<int> seen,
            int currLvl,
            int k)
        {
            if (node == null)
            {
                return;
            }

            if (seen.Contains(node.val))
            {
                return;
            }

            seen.Add(node.val);

            if (currLvl == k)
            {
                result.Add(node.val);
                return;
            }

            Traverse(node.left, result, seen, currLvl + 1, k);
            Traverse(node.right, result, seen, currLvl + 1, k);
        }
    }
}