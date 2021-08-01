namespace Google
{
    using System.Collections.Generic;

    public class Solution
    {
        public int LadderLength(
            string beginWord,
            string endWord,
            IList<string> wordList)
        {
            HashSet<string> wordSet = new HashSet<string>();
            for (int i = 0; i < wordList.Count; i++)
            {
                if (!wordSet.Contains(wordList[i]))
                {
                    wordSet.Add(wordList[i]);
                }
            }

            if (!wordSet.Contains(endWord))
            {
                return 0;
            }

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            int level = 1;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    char[] word = queue.Dequeue().ToCharArray();
                    for (int j = 0; j < word.Length; j++)
                    {
                        char original = word[j];
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            if (word[j] == c)
                            {
                                continue;
                            }

                            word[j] = c;
                            string newWord = new string(word);

                            if (newWord == endWord)
                            {
                                return level + 1;
                            }

                            if (wordSet.Contains(newWord))
                            {
                                queue.Enqueue(newWord);
                                wordSet.Remove(newWord);
                            }
                        }

                        word[j] = original;
                    }
                }

                level++;
            }

            return 0;
        }
    }
}