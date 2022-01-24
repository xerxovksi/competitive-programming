namespace Practice
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public bool IsValid(string s)
        {
            Dictionary<char, char> map = new Dictionary<char, char>
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' }
            };

            List<char> stack = new List<char>();
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]))
                {
                    if (count == 0)
                    {
                        return false;
                    }

                    char last = stack[count - 1];
                    if (last != map[s[i]])
                    {
                        return false;
                    }

                    stack.RemoveAt(count - 1);
                    count--;
                    continue;
                }

                stack.Add(s[i]);
                count++;
            }

            return count == 0;
        }
    }
}