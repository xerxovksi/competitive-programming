namespace Google
{
    public class Solution
    {
        // Moore's Voting Algorithm
        public int MajorityElement(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            int majorityElement = nums[0];
            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == majorityElement)
                {
                    count++;
                }
                else
                {
                    count--;
                    if (count == 0)
                    {
                        majorityElement = nums[i];
                        count = 1;
                    }
                }
            }

            return majorityElement;
        }
    }
}