namespace Google
{
    public class Solution
    {
        public int NumRollsToTarget(int d, int f, int target)
        {
            int mod = (int)Math.Pow(10, 9) + 7;

            int[,] dp = new int[d + 1, target + 1];
            dp[0, 0] = 1;

            for (int i = 1; i <= d; i++)
            {
                for (int j = 1; j <= target; j++)
                {
                    for (int k = 1; k <= f; k++)
                    {
                        if (j < k)
                        {
                            continue;
                        }

                        dp[i, j] = (dp[i, j] + dp[i - 1, j - k]) % mod;
                    }
                }
            }

            return dp[d, target];
        }
    }
}