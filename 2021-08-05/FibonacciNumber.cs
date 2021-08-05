namespace Google
{
    public class Solution
    {
        public int FibonacciNumber(int n)
        {
            int[] fibonacci = new int[n + 1];
            fibonacci[0] = 0;
            fibonacci[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }

            return fibonacci[n];
        }
    }
}