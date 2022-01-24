namespace Practice
{
    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            int digitsLength = digits.Length;
            if (digitsLength == 0)
            {
                return new List<string>();
            }

            Dictionary<char, string> map = new Dictionary<char, string>
            {
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" }
            };

            int runningCount = 1;
            int[] othersCount = new int[digitsLength];
            for (int i = digitsLength - 1; i >= 0; i--)
            {
                othersCount[i] = runningCount;
                runningCount *= map[digits[i]].Length;
            }

            IList<string> result = new List<string>();
            for (int i = 0; i < runningCount; i++)
            {
                string perm = "";
                for (int j = 0; j < digitsLength; j++)
                {
                    perm += Permute(i, map[digits[j]], othersCount[j]);
                }

                result.Add(perm);
            }

            return result;
        }

        private char Permute(int index, string letters, int othersCount)
        {
            return letters[(index / othersCount) % letters.Length];
        }
    }
}