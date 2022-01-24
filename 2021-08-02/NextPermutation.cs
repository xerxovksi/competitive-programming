namespace Practice
{
    using System;

    public class Solution
    {
        public void NextPermutation(int[] nums)
        {
            for (int i = nums.Length - 1; i >= 1; i--)
            {
                if (nums[i - 1] >= nums[i])
                {
                    continue;
                }

                int position = GetNextLargerIndex(nums, nums[i - 1], i);
                Swap(nums, i - 1, position);
                Reverse(nums, i);

                return;
            }

            // If no next permutation is found,
            // then we are required to return the sorted array of nums.
            Array.Sort(nums);
        }

        private int GetNextLargerIndex(int[] nums, int num, int start)
        {
            int min = nums[start];
            int minIndex = start;
            for (int i = start + 1; i < nums.Length; i++)
            {
                // Get the last occurence of this number.
                if (nums[i] > num && nums[i] <= min)
                {
                    min = nums[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        private void Swap(int[] nums, int left, int right)
        {
            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
        }

        private void Reverse(int[] nums, int start)
        {
            int left = start;
            int right = nums.Length - 1;

            while (left < right)
            {
                Swap(nums, left, right);
                left++;
                right--;
            }
        }
    }
}