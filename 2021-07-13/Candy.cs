namespace Practice
{
    using System;

    public class Solution
    {
        public int Candy(int[] ratings)
        {
            if (ratings.Length == 1)
            {
                return 1;
            }

            int[] candies = new int[ratings.Length];
            for (int i = 0; i < ratings.Length; i++)
            {
                candies[i] = 1;
            }

            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    candies[i] = candies[i - 1] + 1;
                }
            }

            int minimumCandies = candies[ratings.Length - 1];
            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                {
                    candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
                }

                minimumCandies += candies[i];
            }

            return minimumCandies;
        }
    }
}