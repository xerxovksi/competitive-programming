namespace Google
{
    using System;

    public class Solution
    {
        public int NthUglyNumber(int n)
        {
            int[] ugly = new int[n + 1];
            ugly[0] = 1;

            int i2 = 0;
            int i3 = 0;
            int i5 = 0;

            int n2 = ugly[i2] * 2;
            int n3 = ugly[i3] * 3;
            int n5 = ugly[i5] * 5;

            for (int i = 1; i < n; i++)
            {
                ugly[i] = Math.Min(Math.Min(n2, n3), n5);

                if (ugly[i] == n2)
                {
                    i2 = i2 + 1;
                    n2 = ugly[i2] * 2;
                }

                if (ugly[i] == n3)
                {
                    i3 = i3 + 1;
                    n3 = ugly[i3] * 3;
                }

                if (ugly[i] == n5)
                {
                    i5 = i5 + 1;
                    n5 = ugly[i5] * 5;
                }
            }

            return ugly[n - 1];
        }
    }
}