namespace Google
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);

            HashSet<string> resultSet = new HashSet<string>();
            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    int left = j + 1;
                    int right = nums.Length - 1;
                    int sum = target - (nums[i] + nums[j]);

                    while (left < right)
                    {
                        if (nums[left] + nums[right] == sum)
                        {
                            string toAdd = string.Join(
                                "-",
                                nums[i],
                                nums[j],
                                nums[left],
                                nums[right]);

                            if (!resultSet.Contains(toAdd))
                            {
                                resultSet.Add(toAdd);
                                result.Add(new List<int>
                            {
                                nums[i],
                                nums[j],
                                nums[left],
                                nums[right]
                            });
                            }

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
                        else if (nums[left] + nums[right] < sum)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
            }

            return result;
        }
    }
}