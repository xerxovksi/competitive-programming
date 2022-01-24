namespace Practice
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> result = new List<string>();
            Generate(n, result, string.Empty, 0, 0);

            return result;
        }

        private void Generate(
            int n,
            IList<string> result,
            string current,
            int open,
            int close)
        {
            if (current.Length == n * 2)
            {
                result.Add(current);
                return;
            }

            if (open < n)
            {
                Generate(n, result, current + "(", open + 1, close);
            }

            if (close < open)
            {
                Generate(n, result, current + ")", open, close + 1);
            }
        }
    }
}