namespace Practice
{
    using System;

    public class Solution
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int rows = text1.Length + 1;
            int cols = text2.Length + 1;

            int[,] dp = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                dp[i, 0] = 0;
            }

            for (int i = 0; i < cols; i++)
            {
                dp[0, i] = 0;
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[rows - 1, cols - 1];
        }
    }
}