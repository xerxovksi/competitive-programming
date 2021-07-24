namespace Google
{
    using System;
    using System.Text;

    public class Solution
    {
        public string ShortestCommonSupersequence(string str1, string str2)
        {
            string lcs = GetLongestCommonSubsequence(str1, str2);
            if (lcs.Length == 0)
            {
                return string.Concat(str1, str2);
            }

            return Merge(str1, str2, lcs);
        }

        private string GetLongestCommonSubsequence(string str1, string str2)
        {
            int[,] dp = new int[str1.Length + 1, str2.Length + 1];
            int i;
            int j;

            for (i = 0; i <= str1.Length; i++)
            {
                dp[i, 0] = 0;
            }

            for (i = 0; i <= str2.Length; i++)
            {
                dp[0, i] = 0;
            }

            for (i = 1; i <= str1.Length; i++)
            {
                for (j = 1; j <= str2.Length; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            StringBuilder lcs = new StringBuilder();
            i = str1.Length;
            j = str2.Length;

            while (i > 0 && j > 0)
            {
                int self = dp[i, j];
                int diagonal = dp[i - 1, j - 1];
                int left = dp[i, j - 1];
                int top = dp[i - 1, j];

                if (diagonal >= left && diagonal >= top)
                {
                    if (self != diagonal)
                    {
                        lcs.Insert(0, str1[i - 1]);
                        i = i - 1;
                        j = j - 1;
                    }
                    else if (top >= left)
                    {
                        i = i - 1;
                    }
                    else
                    {
                        j = j - 1;
                    }

                    continue;
                }

                if (top >= diagonal && top >= left)
                {
                    i = i - 1;
                    continue;
                }

                j = j - 1;
            }

            return lcs.ToString();
        }

        private string Merge(string str1, string str2, string lcs)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            StringBuilder merged = new StringBuilder();
            while (i < str1.Length || j < str2.Length)
            {
                if (i < str1.Length && (k == lcs.Length || str1[i] != lcs[k]))
                {
                    merged.Append(str1[i]);
                    i++;
                    continue;
                }

                if (j < str2.Length && (k == lcs.Length || str2[j] != lcs[k]))
                {
                    merged.Append(str2[j]);
                    j++;
                    continue;
                }

                if (k < lcs.Length)
                {
                    merged.Append(lcs[k]);
                    k++;

                    i++;
                    j++;
                }
            }

            return merged.ToString();
        }
    }
}