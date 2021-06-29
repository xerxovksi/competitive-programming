namespace Google
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            return new WordBreak(
                0,
                s,
                wordDict.ToHashSet(),
                new Dictionary<int, bool>()
            );
        }

        private bool WordBreak(
            int pos,
            string s,
            HashSet<string> dict,
            Dictionary<int, bool> memory)
        {
            if (pos == s.Length)
            {
                return true;
            }

            if (memory.ContainsKey(pos))
            {
                return memory[pos];
            }

            for (int i = pos; i < s.Length; i++)
            {
                string left = s.Substring(pos, i - pos + 1);
                if (dict.Contains(left)
                    && WordBreak(i + 1, s, dict, memory))
                {
                    memory.Add(pos, true);
                    return true;
                }
            }

            memory.Add(pos, false);
            return false;
        }
    }
}