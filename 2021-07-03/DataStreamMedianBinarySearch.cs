namespace Practice
{
    using System.Collections.Generic;

    public class MedianFinder
    {

        IList<int> numbers = null;

        public MedianFinder()
        {
            numbers = new List<int>();
        }

        public void AddNum(int num)
        {
            if (numbers.Count == 0)
            {
                numbers.Add(num);
                return;
            }

            if (num > numbers[numbers.Count - 1])
            {
                numbers.Add(num);
                return;
            }

            int position = GetPosition(num);
            int last = numbers[position];
            numbers[position] = num;

            for (int i = position + 1; i < numbers.Count; i++)
            {
                int temp = numbers[i];
                numbers[i] = last;
                last = temp;
            }

            numbers.Add(last);
        }

        public double FindMedian()
        {
            int length = numbers.Count;
            int mid = length / 2;
            if (length % 2 == 1)
            {
                return numbers[mid];
            }

            return ((double)numbers[mid - 1] + numbers[mid]) / 2;
        }

        private int GetPosition(int num)
        {
            int low = 0;
            int high = numbers.Count - 1;

            while (low < high)
            {
                int mid = (low + high) / 2;

                if (numbers[mid] == num)
                {
                    return mid;
                }

                if (numbers[mid] < num)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            return low;
        }
    }
}