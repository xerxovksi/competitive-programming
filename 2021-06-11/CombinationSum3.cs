namespace Practice
{
    using System.Linq;
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> result = new List<IList<int>>();
            CombinationSum3(
                k,
                n,
                1,
                9,
                new List<int>(),
                result
            );

            return result;
        }

        private void CombinationSum3(
            int k,
            int n,
            int start,
            int end,
            IList<int> combinations,
            IList<IList<int>> result
        )
        {
            if (n < 0)
            {
                return;
            }

            if (n == 0 && combinations.Count == k)
            {
                result.Add(combinations.Select(item => item).ToList());
                return;
            }

            for (int i = start; i <= end && i <= n; i++)
            {
                combinations.Add(i);
                CombinationSum3(
                    k,
                    n - i,
                    start + 1,
                    end,
                    combinations,
                    result);
                combinations.RemoveAt(combinations.Count - 1);
            }
        }
    }
}