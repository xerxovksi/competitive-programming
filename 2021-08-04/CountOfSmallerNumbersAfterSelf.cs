namespace Google
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<int> CountSmaller(int[] nums)
        {
            int[] indices = new int[nums.Length];
            int[] smallerCount = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                indices[i] = i;
                smallerCount[i] = 0;
            }

            MergeSortIndices(
                nums,
                indices,
                0,
                nums.Length - 1,
                smallerCount);

            return smallerCount;
        }

        private int[] MergeSortIndices(
            int[] nums,
            int[] indices,
            int left,
            int right,
            int[] smallerCount)
        {
            if (left == right)
            {
                return new int[] { indices[left] };
            }

            int mid = left + (right - left) / 2;
            int[] leftSub = MergeSortIndices(nums, indices, left, mid, smallerCount);
            int[] rightSub = MergeSortIndices(nums, indices, mid + 1, right, smallerCount);

            return MergeIndices(leftSub, rightSub, nums, smallerCount);
        }

        private int[] MergeIndices(
            int[] leftSub,
            int[] rightSub,
            int[] nums,
            int[] smallerCount)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int sortedIndex = 0;
            int[] sorted = new int[leftSub.Length + rightSub.Length];

            int rightCount = 0;
            while (leftIndex < leftSub.Length && rightIndex < rightSub.Length)
            {
                if (nums[leftSub[leftIndex]] > nums[rightSub[rightIndex]])
                {
                    sorted[sortedIndex] = rightSub[rightIndex];
                    rightIndex++;
                    rightCount++;
                }
                else
                {
                    sorted[sortedIndex] = leftSub[leftIndex];
                    smallerCount[leftSub[leftIndex]] += rightCount;
                    leftIndex++;
                }

                sortedIndex++;
            }

            while (leftIndex < leftSub.Length)
            {
                sorted[sortedIndex] = leftSub[leftIndex];
                smallerCount[leftSub[leftIndex]] += rightCount;
                leftIndex++;
                sortedIndex++;
            }

            while (rightIndex < rightSub.Length)
            {
                sorted[sortedIndex] = rightSub[rightIndex];
                rightIndex++;
                sortedIndex++;
            }

            return sorted;
        }
    }
}