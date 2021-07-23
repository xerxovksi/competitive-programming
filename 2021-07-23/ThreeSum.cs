namespace Google
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);

            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                int left = i + 1;
                int right = nums.Length - 1;
                int target = 0 - nums[i];

                while (left < right)
                {
                    int sum2 = nums[left] + nums[right];
                    if (sum2 == target)
                    {
                        result.Add(
                            new List<int>
                            {
                            nums[i],
                            nums[left],
                            nums[right]
                            });

                        while (left < right && nums[left] == nums[left + 1])
                        {
                            left++;
                        }

                        while (left < right && nums[right] == nums[right - 1])
                        {
                            right--;
                        }

                        left++;
                        right--;
                    }
                    else if (sum2 > target)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }

            return result;
        }
    }
}