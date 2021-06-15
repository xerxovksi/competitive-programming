namespace Google
{
    using System;

    public class Solution
    {
        public int[][] Update01Matrix(int[][] mat)
        {
            int high = 1000;

            int rows = mat.Length;
            int cols = mat[0].Length;
            int[][] result = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                result[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    result[i][j] = high;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        result[i][j] = 0;
                        continue;
                    }

                    if (i > 0)
                    {
                        result[i][j] = Math.Min(
                            result[i][j],
                            1 + result[i - 1][j]);
                    }

                    if (j > 0)
                    {
                        result[i][j] = Math.Min(
                            result[i][j],
                            1 + result[i][j - 1]);
                    }
                }
            }

            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = cols - 1; j >= 0; j--)
                {
                    if (i < rows - 1)
                    {
                        result[i][j] = Math.Min(
                            result[i][j],
                            1 + result[i + 1][j]);
                    }

                    if (j < cols - 1)
                    {
                        result[i][j] = Math.Min(
                            result[i][j],
                            1 + result[i][j + 1]);
                    }
                }
            }

            return result;
        }
    }
}
