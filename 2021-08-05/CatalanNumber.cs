namespace Practice
{
    public class Solution
    {
        /*
            Catalan numbers are a sequence of natural numbers that occurs in many interesting counting problems like following.
            Count the number of expressions containing n pairs of parentheses which are correctly matched. For n = 3, possible expressions are ((())), ()(()), ()()(), (())(), (()()).
            Count the number of possible Binary Search Trees with n keys (See this)
            Count the number of full binary trees (A rooted binary tree is full if every vertex has either two children or no children) with n+1 leaves.
            Given a number n, return the number of ways you can draw n chords in a circle with 2 x n points such that no 2 chords intersect.
        */
        public int CatalanNumber(int n)
        {
            int[] catalan = new int[n + 1];
            catalan[0] = 1;

            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                for (int j = 0; j < i; j++)
                {
                    sum += catalan[j] * catalan[i - j - 1];
                }

                catalan[i] = sum;
            }

            return catalan[n];
        }
    }
}