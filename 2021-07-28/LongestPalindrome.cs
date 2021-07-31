namespace Google
{
    public class Solution
    {
        public int LongestPalindrome(string s)
        {
            // Since there are 128 characters in ASCII.
            int[] frequency = new int[128];
            for (int i = 0; i < s.Length; i++)
            {
                frequency[s[i]]++;
            }

            int result = 0;
            for (int i = 0; i < frequency.Length; i++)
            {
                result += (frequency[i] / 2) * 2;

                // The first half of the check ensures
                // that this condition gets satisfied only once.
                if (result % 2 == 0 && frequency[i] % 2 == 1)
                {
                    result++;
                }
            }

            return result;
        }
    }
}