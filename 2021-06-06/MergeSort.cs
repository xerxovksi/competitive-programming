namespace Google
{
    public class MergeSort
    {
        public int[] SortArray(int[] nums)
        {
            return Sort(nums, 0, nums.Length - 1);
        }

        private int[] Sort(int[] nums, int low, int high)
        {
            int mid = (low + high) / 2;

            if (low < high)
            {
                int[] lowSort = Sort(nums, low, mid);
                int[] highSort = Sort(nums, mid + 1, high);

                return Merge(lowSort, highSort);
            }
            else
            {
                return new int[] { nums[high] };
            }

            return new int[] { nums[mid] };
        }

        public int[] Merge(int[] left, int[] right)
        {
            int resultLength = left.Length + right.Length;
            int[] result = new int[resultLength];

            int i = 0;
            int j = 0;
            int k = 0;

            while (k < resultLength)
            {
                if (i == left.Length && j < right.Length)
                {
                    result[k] = right[j];
                    j++;
                    k++;
                    continue;
                }

                if (j == right.Length && i < left.Length)
                {
                    result[k] = left[i];
                    i++;
                    k++;
                    continue;
                }

                if (left[i] <= right[j])
                {
                    result[k] = left[i];
                    i++;
                }
                else
                {
                    result[k] = right[j];
                    j++;
                }

                k++;
            }

            return result;
        }
    }
}