namespace Practice
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int FindMinArrowShots(int[][] points)
        {
            int n = points.Length;
            if (n == 1)
            {
                return 1;
            }

            Array.Sort(
                points,
                delegate (int[] x, int[] y) { return x[0].CompareTo(y[0]); });

            int result = 0;
            int[] curr = points[0];
            for (int i = 1; i < n; i++)
            {
                int s1 = curr[0];
                int e1 = curr[1];

                int s2 = points[i][0];
                int e2 = points[i][1];

                if ((s1 <= s2 && s2 <= e1) || (s2 <= s1 && s1 <= e2))
                {
                    curr[0] = Math.Max(s1, s2);
                    curr[1] = Math.Min(e1, e2);
                }
                else
                {
                    result++;
                    curr = points[i];
                }
            }

            return result + 1;
        }
    }
}