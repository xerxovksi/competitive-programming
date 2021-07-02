namespace Google
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0)
            {
                return 0;
            }

            Array.Sort(coins);
            int[] dp = new int[amount + 1];
            dp[0] = 0;

            for (int i = 1; i <= amount; i++)
            {
                dp[i] = amount + 1;
            }

            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i < coins[j])
                    {
                        break;
                    }

                    dp[i] = Math.Min(dp[i], 1 + dp[i - coins[j]]);
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
}