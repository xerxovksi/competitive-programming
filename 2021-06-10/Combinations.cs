namespace Google
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Combine(
              n,
              k,
              1,
              new List<int>(),
              result);

            return result;
        }

        private void Combine(
          int n,
          int k,
          int start,
          IList<int> combinations,
          IList<IList<int>> result)
        {
            if (combinations.Count == k)
            {
                result.Add(combinations
                  .Select(item => item)
                  .ToList());

                return;
            }

            for (int i = start; i <= n && combinations.Count <= k; i++)
            {
                combinations.Add(i);
                Combine(n, k, i + 1, combinations, result);
                combinations.RemoveAt(combinations.Count - 1);
            }
        }
    }
}