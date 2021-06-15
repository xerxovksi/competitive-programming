namespace Google
{
	public class Solution
	{
		public bool CanJump(int nums[])
		{
			int lastReachableIndex = nums.Length - 1;
			for (int i = nums.Length - 2; i >= 0; i--)
			{
				if (i + nums[i] >= lastReachableIndex)
				{
					lastReachableIndex = i;
				}
			}

			return lastReachableIndex == 0;
		}
	}
}