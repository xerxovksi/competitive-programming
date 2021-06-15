namespace Google
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
    public int MaxLevelSum(TreeNode root)
    {
      List<int> nodeSums = LevelNodeSums(root);

      var maxSum = nodeSums[0];
      var maxLevel = 1;
      for (int i = 1; i < nodeSums.Count; i++)
      {
        if (nodeSums[i] > maxSum)
        {
          maxSum = nodeSums[i];
          maxLevel = i + 1;
        }
      }

      return maxLevel;
    }

    private List<int> LevelNodeSums(TreeNode root)
    {
      var depth = Depth(root);
      List<int> nodeSums = new List<int>();
      for (int i = 0; i < depth; i++)
      {
        nodeSums.Add(0);
      }

      Traverse(root, nodeSums, 0);
      return nodeSums;
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

    private void Traverse(TreeNode node, List<int> nodeSums, int level)
    {
      if (node == null)
      {
        return;
      }

      nodeSums[level] += node.val;

      Traverse(node.left, nodeSums, level + 1);
      Traverse(node.right, nodeSums, level + 1);
    }
  }
}