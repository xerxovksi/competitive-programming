namespace Practice
{
    /*
        You are given an integer array nums.
        A number x is lonely when it appears only once, and no adjacent numbers (i.e. x + 1 and x - 1) appear in the array.
        Return all lonely numbers in nums. You may return the answer in any order.
    */
    public class Solution
    {
        public IList<int> FindLonely(int[] nums)
        {
            if (nums.Length == 1)
            {
                return new List<int> { nums[0] };
            }

            Array.Sort(nums);

            IList<int> lonely = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    if (nums[i + 1] - nums[i] > 1)
                    {
                        lonely.Add(nums[i]);
                    }

                    continue;
                }

                if (i == nums.Length - 1)
                {
                    if (nums[i] - nums[i - 1] > 1)
                    {
                        lonely.Add(nums[i]);
                    }

                    continue;
                }

                if (nums[i] - nums[i - 1] > 1 && nums[i + 1] - nums[i] > 1)
                {
                    lonely.Add(nums[i]);
                }
            }

            return lonely;
        }
    }
}