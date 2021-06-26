namespace Google
{
    public class Solution
    {
        public int[] MergeSort(int[] nums)
        {
            return MergeSort(0, nums.Length - 1, nums, true);
        }

        private int[] MergeSort(int low, int high, int[] nums, bool isDescending = false)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                int[] lowSort = MergeSort(low, mid, nums, isDescending);
                int[] highSort = MergeSort(mid + 1, high, nums, isDescending);

                return Merge(lowSort, highSort, isDescending);
            }

            return new int[] { nums[high] };
        }

        private int[] Merge(int[] left, int[] right, bool isDescending)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            int resultLength = left.Length + right.Length;
            int[] result = new int[resultLength];
            while (k < resultLength)
            {
                if (i == left.Length)
                {
                    result[k++] = right[j++];
                    continue;
                }

                if (j == right.Length)
                {
                    result[k++] = left[i++];
                    continue;
                }

                if (isDescending)
                {
                    if (left[i] > right[j])
                    {
                        result[k++] = left[i++];
                        continue;
                    }

                    result[k++] = right[j++];
                    continue;
                }

                if (left[i] < right[j])
                {
                    result[k++] = left[i++];
                    continue;
                }

                result[k++] = right[j++];
                continue;
            }

            return result;
        }
    }
}