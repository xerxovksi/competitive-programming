namespace Google
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int NumSquares(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            List<int> perfectSquares = new List<int> { 1 };
            int index = 1;
            int result = 1;
            while (result <= n)
            {
                index = index + 1;
                result = index * index;
                if (result <= n)
                {
                    perfectSquares.Add(result);
                }
            }

            int[] minimumCombinations = new int[n + 1];
            minimumCombinations[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                minimumCombinations[i] = n + 1;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < perfectSquares.Count; j++)
                {
                    if (i < perfectSquares[j])
                    {
                        break;
                    }

                    minimumCombinations[i] = Math.Min(
                        minimumCombinations[i],
                        1 + minimumCombinations[i - perfectSquares[j]]);
                }
            }

            return minimumCombinations[n];
        }
    }
}