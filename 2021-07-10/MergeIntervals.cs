namespace Practice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public int[][] Merge(int[][] intervals)
        {
            int n = intervals.Length;
            if (n == 1)
            {
                return intervals;
            }

            intervals = intervals.OrderBy(item => item[0]).ToArray();
            int i = 1;

            List<int[]> result = new List<int[]>();
            int[] curr = intervals[0];
            while (i < n)
            {
                int s1 = curr[0];
                int e1 = curr[1];

                int s2 = intervals[i][0];
                int e2 = intervals[i][1];

                if ((s1 <= s2 && s2 <= e1) || (s2 <= s1 && s1 <= e2))
                {
                    curr[0] = Math.Min(s1, s2);
                    curr[1] = Math.Max(e1, e2);
                }
                else
                {
                    result.Add(curr.Select(item => item).ToArray());
                    curr = intervals[i];
                }

                i++;
            }

            result.Add(curr);
            return result.ToArray();
        }
    }
}