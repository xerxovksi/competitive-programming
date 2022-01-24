namespace Practice
{
    public class Solution
    {
        public int FindDuplicate(int[] nums)
        {
            int slow = 0;
            int fast = 0;

            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            }
            while (slow != fast);

            fast = 0;
            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[fast];
            }

            return slow;
        }
    }
}