namespace Google
{
    /*
        A reverse pair is a pair (i, j) where 0 <= i < j < nums.length and nums[i] > 2 * nums[j].
    */
    public class Solution
    {
        public int ReversePairs(int[] nums)
        {
            int reversePairs = 0;
            int[] sortedNums = MergeAndCount(
                nums,
                0,
                nums.Length - 1,
                ref reversePairs);

            return reversePairs;
        }

        private int[] MergeAndCount(
            int[] nums,
            int left,
            int right,
            ref int reversePairs)
        {
            if (left == right)
            {
                return new int[] { nums[left] };
            }

            int mid = left + (right - left) / 2;

            int[] leftSub = MergeAndCount(nums, left, mid, ref reversePairs);
            int[] rightSub = MergeAndCount(nums, mid + 1, right, ref reversePairs);

            return Merge(leftSub, rightSub, ref reversePairs);
        }

        private int[] Merge(int[] leftSub, int[] rightSub, ref int reversePairs)
        {
            int[] merged = new int[leftSub.Length + rightSub.Length];
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < leftSub.Length && j < rightSub.Length)
            {
                if (leftSub[i] <= rightSub[j])
                {
                    merged[k] = leftSub[i];
                    i++;
                }
                else
                {
                    merged[k] = rightSub[j];
                    j++;
                }

                k++;
            }

            while (i < leftSub.Length)
            {
                merged[k] = leftSub[i];
                i++;
                k++;
            }

            while (j < rightSub.Length)
            {
                merged[k] = rightSub[j];
                j++;
                k++;
            }

            i = 0;
            j = 0;

            while (i < leftSub.Length && j < rightSub.Length)
            {
                if ((long)leftSub[i] > (long)rightSub[j] * 2)
                {
                    reversePairs += leftSub.Length - i;
                    j++;
                }
                else
                {
                    i++;
                }
            }

            return merged;
        }
    }
}