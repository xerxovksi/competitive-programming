namespace Google
{
    public class Solution
    {
        public int MinPathSum(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int[][] result = new int[rows][];
            result[0] = new int[cols];
            result[0][0] = grid[0][0];

            for (int i = 1; i < rows; i++)
            {
                result[i] = new int[cols];
                result[i][0] = result[i - 1][0] + grid[i][0];
            }

            for (int j = 1; j < cols; j++)
            {
                result[0][j] = result[0][j - 1] + grid[0][j];
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    result[i][j] = Math.Min(result[i - 1][j], result[i][j - 1])
                        + grid[i][j];
                }
            }

            return result[rows - 1][cols - 1];
        }
    }
}