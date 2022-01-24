namespace Practice
{
    using System;

    public class Solution
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            if (mat.Length == 0 || mat[0].Length == 0)
            {
                return mat;
            }

            int max = mat.Length * mat[0].Length;
            int[][] distance = new int[mat.Length][];

            for (int i = 0; i < mat.Length; i++)
            {
                distance[i] = new int[mat[i].Length];
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        distance[i][j] = 0;
                        continue;
                    }

                    int top = i > 0 ? distance[i - 1][j] : max;
                    int left = j > 0 ? distance[i][j - 1] : max;

                    distance[i][j] = Math.Min(top, left) + 1;
                }
            }

            for (int i = mat.Length - 1; i >= 0; i--)
            {
                for (int j = mat[0].Length - 1; j >= 0; j--)
                {
                    if (mat[i][j] == 0)
                    {
                        distance[i][j] = 0;
                        continue;
                    }

                    int down = i < mat.Length - 1 ? distance[i + 1][j] : max;
                    int right = j < mat[0].Length - 1 ? distance[i][j + 1] : max;
                    distance[i][j] = Math.Min(
                        distance[i][j],
                        Math.Min(down, right) + 1);
                }
            }

            return distance;
        }
    }
}
