namespace Google
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<int> MajorityElement(int[] nums)
        {
            int majority1 = -1;
            int count1 = 0;

            int majority2 = -1;
            int count2 = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == majority1)
                {
                    count1++;
                }
                else if (nums[i] == majority2)
                {
                    count2++;
                }
                else if (count1 == 0)
                {
                    majority1 = nums[i];
                    count1++;
                }
                else if (count2 == 0)
                {
                    majority2 = nums[i];
                    count2++;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }

            count1 = 0;
            count2 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == majority1)
                {
                    count1++;
                }
                else if (nums[i] == majority2)
                {
                    count2++;
                }
            }

            IList<int> result = new List<int>();
            int limit = nums.Length / 3;

            if (count1 > limit)
            {
                result.Add(majority1);
            }

            if (count2 > limit)
            {
                result.Add(majority2);
            }

            return result;
        }
    }
}