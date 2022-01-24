namespace Practice
{
    using System;

    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            int start = 0, end = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int oddLength = ExpandAroundCenter(s, i, i);
                int evenLength = ExpandAroundCenter(s, i, i + 1);
                int maxLength = Math.Max(oddLength, evenLength);

                if (maxLength > end - start)
                {
                    start = i - (maxLength - 1) / 2;
                    end = i + maxLength / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }

        private int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }
    }
}