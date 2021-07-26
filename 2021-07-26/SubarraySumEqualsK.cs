namespace Google
{
    using System.Collections.Generic;

    public class Solution
    {
        public int SubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> seen = new Dictionary<int, int>();

            int currentSum = 0;
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                currentSum = currentSum + nums[i];

                if (currentSum == k)
                {
                    count++;
                }

                if (seen.ContainsKey(currentSum - k))
                {
                    count = count + seen[currentSum - k];
                }

                if (seen.ContainsKey(currentSum))
                {
                    seen[currentSum] = seen[currentSum] + 1;
                }
                else
                {
                    seen.Add(currentSum, 1);
                }
            }

            return count;
        }
    }
}