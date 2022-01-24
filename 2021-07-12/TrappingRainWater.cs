namespace Practice
{
    using System;

    public class Solution
    {
        public int Trap(int[] height)
        {
            if (height.Length <= 2)
            {
                return 0;
            }

            int[] leftMax = new int[height.Length];
            int[] rightMax = new int[height.Length];

            leftMax[0] = 0;
            rightMax[height.Length - 1] = 0;

            int i;
            int j;
            for (i = 1, j = height.Length - 2; i < height.Length && j >= 0; i++, j--)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], height[i - 1]);
                rightMax[j] = Math.Max(rightMax[j + 1], height[j + 1]);
            }

            int sum = 0;
            for (i = 0; i < height.Length; i++)
            {
                sum = sum + Math.Max(
                    0,
                    Math.Min(leftMax[i], rightMax[i]) - height[i]);
            }

            return sum;
        }

        public int TrapSpaceOptimized(int[] height)
        {
            if (height.Length <= 2)
            {
                return 0;
            }

            int left = 1;
            int right = height.Length - 2;

            int leftMax = 0;
            int rightMax = 0;

            int sum = 0;

            while (left <= right)
            {
                leftMax = Math.Max(leftMax, height[left - 1]);
                rightMax = Math.Max(rightMax, height[right + 1]);

                int min = Math.Min(leftMax, rightMax);

                if (leftMax == min)
                {
                    sum = sum + Math.Max(0, min - height[left]);
                    left++;
                }
                else
                {
                    sum = sum + Math.Max(0, min - height[right]);
                    right--;
                }
            }

            return sum;
        }
    }
}