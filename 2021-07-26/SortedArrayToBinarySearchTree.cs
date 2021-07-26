namespace Google
{
    public class TreeNode
    {
        public int val { get; set; }

        public TreeNode left { get; set; }

        public TreeNode right { get; set; }

        public TreeNode(
            int val = null,
            TreeNode left = null,
            TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return Convert(nums, 0, nums.Length - 1);
        }

        private TreeNode Convert(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = start + (end - start) / 2;

            TreeNode root = new TreeNode(nums[mid]);
            root.left = Convert(nums, start, mid - 1);
            root.right = Convert(nums, mid + 1, end);

            return root;
        }
    }
}