namespace Practice
{
    using System;

    public class Solution
    {
        public int PartitionDisjoint(int[] nums)
        {
            int[] leftMax = new int[nums.Length];
            leftMax[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], nums[i]);
            }

            int[] rightMin = new int[nums.Length];
            rightMin[nums.Length - 1] = nums[nums.Length - 1];
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                rightMin[i] = Math.Min(rightMin[i + 1], nums[i]);
            }

            int leftPartitionSize = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (leftMax[i - 1] <= rightMin[i])
                {
                    leftPartitionSize = i;
                    break;
                }
            }

            return leftPartitionSize;
        }
    }
}