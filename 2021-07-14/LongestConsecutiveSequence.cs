namespace Google
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return nums.Length;
            }

            HashSet<int> numSet = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!numSet.Contains(nums[i]))
                {
                    numSet.Add(nums[i]);
                }
            }

            int longest = 1;
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (seen.Contains(nums[i]))
                {
                    continue;
                }

                if (numSet.Contains(nums[i] - 1))
                {
                    continue;
                }

                int running = 1;
                seen.Add(nums[i]);

                int curr = nums[i] + 1;
                while (numSet.Contains(curr))
                {
                    seen.Add(curr);
                    running++;

                    curr = curr + 1;
                }

                longest = Math.Max(longest, running);
            }

            return longest;
        }
    }
}