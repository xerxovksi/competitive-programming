namespace Practice
{
    using System;
    using System.Linq;

    public class Solution
    {
        public int MaxHeight(int[][] cuboids)
        {
            for (int i = 0; i < cuboids.Length; i++)
            {
                Array.Sort(cuboids[i]);
            }

            int[][] sortedCuboids = cuboids
                .OrderBy(cuboid => cuboid[0])
                .OrderBy(cuboid => cuboid[1])
                .OrderBy(cuboid => cuboid[2])
                .ToArray();

            int maxHeight = 0;
            int[] lis = new int[cuboids.Length];

            for (int i = 0; i < sortedCuboids.Length; i++)
            {
                lis[i] = sortedCuboids[i][2];
                for (int j = 0; j < i; j++)
                {
                    if (
                        sortedCuboids[j][0] <= sortedCuboids[i][0]
                        && sortedCuboids[j][1] <= sortedCuboids[i][1]
                        && sortedCuboids[j][2] <= sortedCuboids[i][2])
                    {
                        lis[i] = Math.Max(lis[i], lis[j] + sortedCuboids[i][2]);
                    }
                }

                maxHeight = Math.Max(maxHeight, lis[i]);
            }

            return maxHeight;
        }
    }
}