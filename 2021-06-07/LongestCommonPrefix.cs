namespace Google
{
    using System;
    using System.Text;

    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
            {
                return "";
            }

            string longestCommonPrefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                longestCommonPrefix = LongestCommonPrefix(
                    longestCommonPrefix,
                    strs[i]);

                if (longestCommonPrefix == "")
                {
                    return "";
                }
            }

            return longestCommonPrefix;
        }

        private string LongestCommonPrefix(string left, string right)
        {
            int n = Math.Min(left.Length, right.Length);
            StringBuilder commonSub = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                if (left[i] != right[i])
                {
                    return commonSub.ToString();
                }

                commonSub.Append(left[i]);
            }

            return commonSub.ToString();
        }
    }
}
