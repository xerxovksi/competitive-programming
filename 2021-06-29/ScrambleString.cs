using System.Collections.Generic;

public class Solution
{
    public bool IsScramble(string s1, string s2)
    {
        return Check(s1, s2, new Dictionary<string, bool>());
    }

    private bool Check(string s1, string s2, Dictionary<string, bool> memory)
    {
        int n = s1.Length;
        string key = $"{s1}|{s2}";

        if (n == 1)
        {
            return s1 == s2;
        }

        if (s1 == s2)
        {
            return true;
        }

        if (memory.ContainsKey(key))
        {
            return memory[key];
        }

        if (!IsAnagram(s1.ToLower(), s2.ToLower(), n))
        {
            memory[key] = false;
            return false;
        }

        for (int i = 1; i < n; i++)
        {
            if ((Check(s1.Substring(0, i), s2.Substring(0, i), memory)
                && Check(s1.Substring(i), s2.Substring(i), memory)
                || (Check(s1.Substring(0, i), s2.Substring(n - i), memory)
                && Check(s1.Substring(i), s2.Substring(0, n - i), memory))))
            {
                memory.Add(key, true);
                return true;
            }
        }

        memory.Add(key, false);
        return false;
    }

    private bool IsAnagram(string s1, string s2, int n)
    {
        int[] first = new int[26];
        int[] second = new int[26];

        for (int i = 0; i < n; i++)
        {
            first[(int)s1[i] - 'a']++;
            second[(int)s2[i] - 'a']++;
        }

        return Enumerable.SequenceEqual(first, second);
    }
}