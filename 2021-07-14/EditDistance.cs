namespace Practice
{
    using System;

    public class Solution
    {
        public int MinDistance(string word1, string word2)
        {
            int[,] lev = new int[word1.Length + 1, word2.Length + 1];

            for (int i = 0; i <= word1.Length; i++)
            {
                lev[i, 0] = i;
            }

            for (int i = 0; i <= word2.Length; i++)
            {
                lev[0, i] = i;
            }

            for (int i = 1; i <= word1.Length; i++)
            {
                for (int j = 1; j <= word2.Length; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        lev[i, j] = lev[i - 1, j - 1];
                        continue;
                    }

                    lev[i, j] = 1 + Math.Min(
                        lev[i - 1, j - 1],
                        Math.Min(lev[i - 1, j], lev[i, j - 1]));
                }
            }

            return lev[word1.Length, word2.Length];
        }
    }
}