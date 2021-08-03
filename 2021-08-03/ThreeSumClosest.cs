namespace Google
{
    using System;

    public class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);

            int difference = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == target)
                    {
                        return sum;
                    }
                    else if (sum > target)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }

                    if (Math.Abs(target - sum) < Math.Abs(difference))
                    {
                        difference = target - sum;
                    }
                }
            }

            return target - difference;
        }
    }
}