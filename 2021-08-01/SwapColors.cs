namespace Google
{
    public class Solution
    {
        public void SortColors(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int center = 0;

            while (center <= right)
            {
                if (nums[center] == 0)
                {
                    Swap(ref nums[left], ref nums[center]);
                    left++;
                    center++;
                }
                else if (nums[center] == 1)
                {
                    center++;
                }
                else if (nums[center] == 2)
                {
                    Swap(ref nums[right], ref nums[center]);
                    right--;
                }
            }
        }

        private void Swap(ref int num1, ref int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }
    }
}