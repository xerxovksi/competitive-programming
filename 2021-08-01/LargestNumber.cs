namespace Google
{
    using System;
    using System.Text;

    public class Solution
    {
        public string LargestNumber(int[] nums)
        {
            bool allZeros = true;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    allZeros = false;
                    break;
                }
            }

            if (allZeros)
            {
                return "0";
            }

            /*
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    long leftRight = Convert.ToInt64($"{nums[i]}{nums[j]}");
                    long rightLeft = Convert.ToInt64($"{nums[j]}{nums[i]}");

                    if (rightLeft < leftRight)
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            */

            Array.Sort(
                nums,
                delegate (int left, int right)
                {
                    long leftRight = Convert.ToInt64($"{left}{right}");
                    long rightLeft = Convert.ToInt64($"{right}{left}");

                    return leftRight < rightLeft ? -1 : 1;
                });

            StringBuilder largestNumberBuilder = new StringBuilder();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                largestNumberBuilder.Append(nums[i]);
            }

            return largestNumberBuilder.ToString();
        }
    }
}