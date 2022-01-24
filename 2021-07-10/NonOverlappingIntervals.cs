namespace Practice
{
    using System;

    public class Solution
    {
        public int EraseOverlapIntervals(int[][] intervals)
        {
            int n = intervals.Length;
            if (n == 1)
            {
                return 0;
            }

            Array.Sort(
                intervals,
                delegate (int[] x, int[] y) { return x[0].CompareTo(y[0]); });

            int[] prev = intervals[0];
            int result = 0;
            for (int i = 1; i < n; i++)
            {
                if (intervals[i][0] < prev[1])
                {
                    result++;

                    if (intervals[i][1] < prev[1])
                    {
                        prev = intervals[i];
                    }
                }
                else
                {
                    prev = intervals[i];
                }
            }

            return result;
        }
    }
}