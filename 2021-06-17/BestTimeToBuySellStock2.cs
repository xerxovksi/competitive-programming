namespace Google
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    profit = profit + prices[i] - prices[i - 1];
                }
            }

            return profit;
        }
    }
}