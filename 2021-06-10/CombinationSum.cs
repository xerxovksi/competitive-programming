namespace Practice
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            CombinationSum(
              candidates,
              target,
              0,
              new List<int>(),
              result);

            return result;
        }

        private void CombinationSum(
          int[] candidates,
          int target,
          int index,
          IList<int> combinations,
          IList<IList<int>> result)
        {
            if (target < 0)
            {
                return;
            }

            if (target == 0)
            {
                result.Add(combinations.Select(item => item).ToList());
                return;
            }

            if (index < candidates.Length)
            {
                combinations.Add(candidates[index]);
                CombinationSum(
                  candidates,
                  target - candidates[index],
                  index,
                  combinations,
                  result);

                combinations.RemoveAt(combinations.Count - 1);
                CombinationSum(
                  candidates,
                  target,
                  index + 1,
                  combinations,
                  result);
            }
        }
    }
}