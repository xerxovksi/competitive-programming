namespace Practice
{
    public class TwoSumSorted
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int low = 0;
            int high = numbers.Length - 1;

            while (low < high)
            {
                if (numbers[low] + numbers[high] == target)
                {
                    return new int[] { low, high };
                }
                else if (numbers[low] + numbers[high] < target)
                {
                    low++;
                }
                else
                {
                    high--;
                }
            }

            return new int[] { };
        }
    }
}