namespace Practice
{
    using System.Collections.Generic;
    using System.Text;

    public class Solution
    {
        public IList<string> GenerateBinaryStrings(string str)
        {
            if (!str.Contains('?'))
            {
                return new List<string> { str };
            }

            IList<string> result = new List<string>();
            GenerateBinaryStrings(new StringBuilder(str), 0, result);

            return result;
        }

        private void GenerateBinaryStrings(StringBuilder str, int index, IList<string> result)
        {
            if (index == str.Length)
            {
                result.Add(str.ToString());
                return;
            }

            if (str[index] == '?')
            {
                str[index] = '0';
                GenerateBinaryStrings(str, index + 1, result);

                str[index] = '1';
                GenerateBinaryStrings(str, index + 1, result);

                str[index] = '?';
            }
            else
            {
                GenerateBinaryStrings(str, index + 1, result);
            }
        }
    }
}