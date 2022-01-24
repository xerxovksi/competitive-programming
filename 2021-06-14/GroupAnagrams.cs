namespace Practice
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> wordMap = new Dictionary<string, IList<string>>();
            IList<IList<string>> result = new List<IList<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                string orderedStr = string.Concat(strs[i].OrderBy(c => c));
                if (wordMap.ContainsKey(orderedStr))
                {
                    wordMap[orderedStr].Add(strs[i]);
                }
                else
                {
                    wordMap.Add(orderedStr, new List<string> { strs[i] });
                }
            }

            return wordMap.Values.ToList();
        }
    }
}