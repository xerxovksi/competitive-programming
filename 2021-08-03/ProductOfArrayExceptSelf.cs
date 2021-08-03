namespace Google
{
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] products = new int[nums.Length];
            products[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                products[i] = products[i - 1] * nums[i - 1];
            }

            int product = 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                product = product * nums[i + 1];
                products[i] = products[i] * product;
            }

            return products;
        }
    }
}