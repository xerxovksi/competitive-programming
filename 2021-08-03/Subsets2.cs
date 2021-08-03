namespace Google
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);

            IList<IList<int>> subsets = new List<IList<int>>();
            subsets.Add(new List<int>());

            Combine(nums, new List<int>(), subsets, 0);
            return subsets;
        }

        private void Combine(
            int[] nums,
            IList<int> current,
            IList<IList<int>> subsets,
            int index)
        {
            if (current.Count == nums.Length)
            {
                subsets.Add(current.Select(item => item).ToList());
                return;
            }

            if (current.Count > 0)
            {
                subsets.Add(current.Select(item => item).ToList());
            }

            for (int i = index; i < nums.Length; i++)
            {
                if (i > index && nums[i] == nums[i - 1])
                {
                    continue;
                }

                current.Add(nums[i]);
                Combine(nums, current, subsets, i + 1);

                current.RemoveAt(current.Count - 1);
            }
        }
    }
}