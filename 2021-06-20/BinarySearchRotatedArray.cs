namespace Google
{
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;

            while(low <= high)
            {
                int mid = (low + high) / 2;
                if (target == nums[mid])
                {
                    return mid;
                }

                if (nums[low] <= target && target <= nums[mid])
                {
                    high = mid - 1;
                    continue;
                }

                if (nums[mid] <= target && target <= nums[high])
                {
                    low = mid + 1;
                    continue;
                }

                if (nums[low] > nums[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }
    }
}