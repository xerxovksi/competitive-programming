namespace Google
{
    using System;
    using System.Collections.Generic;

    public class ThreeSum
    {
        public IList<IList<int>> GetThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int low = i + 1;
                    int high = nums.Length - 1;
                    int target = 0 - nums[i];

                    while (low < high)
                    {
                        if (nums[low] + nums[high] == target)
                        {
                            result.Add(
                                new List<int>
                                {
                      nums[i],
                      nums[low],
                      nums[high]
                                });

                            while (low < high && nums[low] == nums[low + 1])
                            {
                                low++;
                            }

                            while (low < high && nums[high] == nums[high - 1])
                            {
                                high--;
                            }

                            low++;
                            high--;
                        }
                        else if (nums[low] + nums[high] < target)
                        {
                            low++;
                        }
                        else
                        {
                            high--;
                        }
                    }
                }
            }

            return result;
        }
    }
}