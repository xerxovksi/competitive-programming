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
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
      var depth = Depth(root);
      IList<IList<int>> nodes = new List<IList<int>>();
      for (int i = 0; i < depth; i++)
      {
        nodes.Add(new List<int>());
      }

      Traverse(root, nodes, 0);
      return nodes;
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

    private void Traverse(TreeNode node, IList<IList<int>> nodes, int level)
    {
      if (node == null)
      {
        return;
      }

      nodes[level].Add(node.val);

      Traverse(node.left, nodes, level + 1);
      Traverse(node.right, nodes, level + 1);
    }
  }
}