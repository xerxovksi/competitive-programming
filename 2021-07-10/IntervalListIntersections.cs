namespace Google
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            int n1 = firstList.Length;
            int n2 = secondList.Length;

            int i = 0;
            int j = 0;
            List<int[]> result = new List<int[]>();
            while (i < n1 && j < n2)
            {
                int s1 = firstList[i][0];
                int e1 = firstList[i][1];

                int s2 = secondList[j][0];
                int e2 = secondList[j][1];

                if ((s1 <= s2 && s2 <= e1) || s2 <= s1 && s1 <= e2)
                {
                    int start = Math.Max(s1, s2);
                    int end = Math.Min(e1, e2);
                    result.Add(new int[] { start, end });
                }

                if (e2 > e1)
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return result.ToArray();
        }
    }
}