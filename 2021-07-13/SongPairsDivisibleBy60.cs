namespace Practice
{
    using System.Collections.Generic;

    public class Solution
    {
        public int NumPairsDivisibleBy60(int[] time)
        {
            // Original  -> 60   30   20   120   150   100   40
            // Modulo 60 -> 0    30   20   0     30    40    40

            // `moduloMap`: [{0, { 60, 120 }}, { 30, { 30, 150 }}, { 20, { 20 } }, { 40, { 100, 40 }}]
            // For keys 0 and 30 -> NC2
            // For others        -> Left x Right
            // To avoid repetition: Maintain a HashSet of `seen`

            Dictionary<int, int> moduloMap = new Dictionary<int, int>();
            for (int i = 0; i < time.Length; i++)
            {
                int mod = time[i] % 60;
                if (moduloMap.ContainsKey(mod))
                {
                    moduloMap[mod] = moduloMap[mod] + 1;
                }
                else
                {
                    moduloMap.Add(mod, 1);
                }
            }

            int pairs = 0;
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < time.Length; i++)
            {
                int mod = time[i] % 60;
                if (seen.Contains(mod))
                {
                    continue;
                }
                else
                {
                    seen.Add(mod);
                    seen.Add(60 - mod);
                }

                if (mod == 0 || mod == 30)
                {
                    pairs += Combinations(moduloMap[mod]);
                    continue;
                }

                if (moduloMap.ContainsKey(60 - mod))
                {
                    pairs += moduloMap[mod] * moduloMap[60 - mod];
                }
            }

            return pairs;
        }

        private int Combinations(int n)
        {
            if (n < 2)
            {
                return 0;
            }

            return (n * (n - 1)) / 2;
        }
    }
}