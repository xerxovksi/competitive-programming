namespace Practice
{
    using System;

    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int[] result = new int[prices.Length];
            result[0] = 0;
            int minPos = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                result[i] = Math.Max(result[i - 1], prices[i] - prices[minPos]);
                if (prices[i] < prices[minPos])
                {
                    minPos = i;
                }
            }

            return result[prices.Length - 1];
        }
    }
}