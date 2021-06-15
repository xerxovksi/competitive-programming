namespace Google
{
    using System;

    public class Solution
    {
        public int Jump(int[] nums)
        {
            if (nums.Length <= 1 || nums[0] == 0)
            {
                return 0;
            }

            int currPos = nums[0];
            int farthest = nums[0];
            int jumps = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == nums.Length - 1)
                {
                    return jumps;
                }

                farthest = Math.Max(farthest, i + nums[i]);

                if (i == currPos)
                {
                    jumps++;
                    currPos = farthest;
                }
            }

            return jumps;
        }
    }
}