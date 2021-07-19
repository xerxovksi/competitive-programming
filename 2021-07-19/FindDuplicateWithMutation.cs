namespace Google
{
    using System;
    using System.Linq;

    public class Solution
    {
        public int FindDuplicate(int[] nums)
        {
            int[] numsCopy = nums.Select(item => item).ToArray();
            int duplicate = 0;
            for (int i = 0; i < numsCopy.Length; i++)
            {
                int index = Math.Abs(numsCopy[i]);
                if (numsCopy[index] < 0)
                {
                    duplicate = index;
                    break;
                }

                numsCopy[index] *= -1;
            }

            return duplicate;
        }
    }
}