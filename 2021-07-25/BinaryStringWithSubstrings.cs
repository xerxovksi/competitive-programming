namespace Practice
{
    using System.Text;

    public class Solution
    {
        public bool QueryString(string s, int n)
        {
            HashSet<int> seen = new HashSet<int>();
            for (int i = n; i >= 1; i--)
            {
                if (seen.Contains(i))
                {
                    int child = i / 2;
                    if (!seen.Contains(child))
                    {
                        seen.Add(child);
                    }

                    continue;
                }

                if (!s.Contains(ToBinary(i)))
                {
                    return false;
                }
                else
                {
                    int child = i / 2;
                    if (!seen.Contains(child))
                    {
                        seen.Add(child);
                    }
                }
            }

            return true;
        }

        private string ToBinary(int n)
        {
            StringBuilder binary = new StringBuilder();
            for (int i = n; i > 0; i = i / 2)
            {
                binary.Insert(0, i % 2);
            }

            return binary.ToString();
        }
    }
}