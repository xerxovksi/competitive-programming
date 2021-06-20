namespace Google
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int MinTaps(int n, int[] ranges)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int[] dist = new int[n + 1];

            for (int i = 0; i < ranges.Length; i++)
            {
                int low = Math.Max(0, i - ranges[i]);
                int high = Math.Min(i + ranges[i], n);

                if (!map.ContainsKey(low))
                {
                    map.Add(low, high);
                }
                else
                {
                    map[low] = Math.Max(map[low], high);
                }
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                dist[i] = map.ContainsKey(i) ? map[i] - i : 0;
            }

            if (dist[0] == 0)
            {
                return -1;
            }

            int farthest = dist[0];
            int currPos = dist[0];
            int reach = 1;

            for (int i = 0; i < n; i++)
            {
                farthest = Math.Max(farthest, i + dist[i]);

                if (i == currPos)
                {
                    reach++;
                    currPos = farthest;
                }
            }

            return currPos == n ? reach : -1;
        }
    }
}