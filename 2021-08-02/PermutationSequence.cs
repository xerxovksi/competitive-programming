namespace Google
{
    using System.Collections.Generic;
    using System.Text;

    public class Solution
    {
        public string GetPermutation(int n, int k)
        {
            List<int> numbers = GetNumbers(n);
            List<int> factorials = GetFactorials(n);

            StringBuilder permutation = new StringBuilder();
            GetPermutation(
                numbers,
                k,
                factorials,
                permutation);

            return permutation.ToString();
        }

        private List<int> GetNumbers(int n)
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            return numbers;
        }

        private List<int> GetFactorials(int n)
        {
            List<int> factorials = new List<int> { 1 };
            int runner = 1;
            for (int i = 1; i <= n; i++)
            {
                runner = runner * i;
                factorials.Add(runner);
            }

            return factorials;
        }

        private void GetPermutation(
            List<int> numbers,
            int k,
            List<int> factorials,
            StringBuilder permutation)
        {
            int n = numbers.Count;
            if (n == 1)
            {
                permutation.Append(numbers[0]);
                return;
            }

            int index = k / factorials[n - 1];
            if (index > 0 && k % factorials[n - 1] == 0)
            {
                index--;
            }

            permutation.Append(numbers[index]);
            numbers.RemoveAt(index);

            k = k - (factorials[n - 1] * index);
            GetPermutation(numbers, k, factorials, permutation);
        }
    }
}