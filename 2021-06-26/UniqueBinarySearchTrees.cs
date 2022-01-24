namespace Practice
{
    public class Solution
    {
        public int NumTrees(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            int[] memory = new int[n + 1];
            memory[0] = 1;
            return NumTrees(n, memory);
        }

        private int NumTrees(int n, int[] memory)
        {
            if (memory[n] != 0)
            {
                return memory[n];
            }

            int trees = 0;
            for (int i = 1; i <= n; i++)
            {
                trees = trees + (NumTrees(i - 1, memory) * NumTrees(n - i, memory));
            }

            memory[n] = trees;
            return trees;
        }
    }
}