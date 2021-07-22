namespace Google
{
    using System;

    public class Solution
    {
        public int MaxEnvelopes(int[][] envelopes)
        {
            if (envelopes.Length == 1)
            {
                return 1;
            }

            int[][] sorted = envelopes
                .OrderBy(element => element[0])
                .ThenBy(element => element[1]).ToArray();

            int n = envelopes.Length;
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
            }

            int maximum = 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (sorted[i][0] > sorted[j][0]
                       && sorted[i][1] > sorted[j][1]
                       && dp[i] < 1 + dp[j])
                    {
                        dp[i] = 1 + dp[j];
                        maximum = Math.Max(maximum, dp[i]);
                    }
                }
            }

            return maximum;
        }
    }
}