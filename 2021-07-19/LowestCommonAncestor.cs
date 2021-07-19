namespace Google
{
    using System.Collections.Generic;

    public class Solution
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            Dictionary<int, TreeNode> parents = new Dictionary<int, TreeNode>();
            TraverseParents(root, parents);

            HashSet<int> visited = new HashSet<int> { p.val };
            while (parents.ContainsKey(p.val))
            {
                TreeNode parent = parents[p.val];
                visited.Add(parent.val);
                p = parent;
            }

            if (visited.Contains(q.val))
            {
                return q;
            }

            TreeNode commonAncestor = root;
            while (parents.ContainsKey(q.val))
            {
                TreeNode parent = parents[q.val];
                if (visited.Contains(parent.val))
                {
                    commonAncestor = parent;
                    break;
                }

                q = parent;
            }

            return commonAncestor;
        }

        private void TraverseParents(TreeNode root, Dictionary<int, TreeNode> parents)
        {
            if (root == null)
            {
                return;
            }

            TreeNode left = root.left;
            TreeNode right = root.right;

            if (left != null)
            {
                parents.Add(left.val, root);
                TraverseParents(left, parents);
            }

            if (right != null)
            {
                parents.Add(right.val, root);
                TraverseParents(right, parents);
            }
        }
    }
}