namespace Google
{
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

    public class PruneBinaryTree
    {
        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            root.left = PruneTree(root.left);
            root.right = PruneTree(root.right);

            if (root.val == 1
               || root.left != null
               || root.right != null)
            {
                return root;
            }

            return null;
        }
    }
}