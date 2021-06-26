namespace Google
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int LengthOfLIS_UsingDP(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 1;
            }

            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = 1;
            }

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);
                    }
                }
            }

            int max = dp[0];
            for (int i = 1; i < dp.Length; i++)
            {
                max = Math.Max(max, dp[i]);
            }

            return max;
        }

        public int LengthOfLIS_UsingLinearSearch(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 1;
            }

            List<int> sub = new List<int> { nums[0] };
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > sub[sub.Count - 1])
                {
                    sub.Add(nums[i]);
                    continue;
                }

                int j;
                for (j = 0; j < sub.Count; j++)
                {
                    if (nums[i] <= sub[j])
                    {
                        break;
                    }
                }

                if (j < sub.Count)
                {
                    sub[j] = nums[i];
                }
            }

            return sub.Count;
        }

        public int LengthOfLIS_UsingLinearSearch(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 1;
            }

            List<int> sub = new List<int> { nums[0] };
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > sub[sub.Count - 1])
                {
                    sub.Add(nums[i]);
                    continue;
                }

                int position = BinarySearch(sub, nums[i]);
                sub[position] = nums[i];
            }

            return sub.Count;
        }

        private int BinarySearch(List<int> sub, int num)
        {
            int low = 0;
            int high = sub.Count - 1;

            while (low < high)
            {
                int mid = (low + high) / 2;
                if (sub[mid] == num)
                {
                    return mid;
                }

                if (sub[mid] < num)
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