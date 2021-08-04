namespace Google
{
    public class Solution
    {
        public int[] SortIndices(int[] nums)
        {
            int[] indices = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                indices[i] = i;
            }

            int[] sortedIndices = MergeSortIndices(
                nums,
                indices,
                0,
                indices.Length - 1);

            return sortedIndices;
        }

        private int[] MergeSortIndices(
            int[] nums,
            int[] indices,
            int left,
            int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                int[] leftIndices = MergeSortIndices(nums, indices, left, mid);
                int[] rightIndices = MergeSortIndices(nums, indices, mid + 1, right);

                return MergeIndices(leftIndices, rightIndices, nums);
            }
            else if (left == right)
            {
                return new int[] { indices[left] };
            }
            else
            {
                return new int[] { indices[right] };
            }
        }

        private int[] MergeIndices(
            int[] leftIndices,
            int[] rightIndices,
            int[] nums)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int[] sortedIndices = new int[leftIndices.Length + rightIndices.Length];

            while (i < leftIndices.Length && j < rightIndices.Length)
            {
                if (nums[leftIndices[i]] > nums[rightIndices[j]])
                {
                    sortedIndices[k] = leftIndices[i];
                    i++;
                }
                else
                {
                    sortedIndices[k] = rightIndices[j];
                    j++;
                }

                k++;
            }

            while (i < leftIndices.Length)
            {
                sortedIndices[k] = leftIndices[i];
                i++;
                k++;
            }

            while (j < rightIndices.Length)
            {
                sortedIndices[k] = rightIndices[j];
                j++;
                k++;
            }

            return sortedIndices;
        }
    }
}