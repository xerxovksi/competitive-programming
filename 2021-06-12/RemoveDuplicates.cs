namespace Google
{
	public class Solution
	{
		public int RemoveDuplicates(int[] num)
		{
			int length = num.Length;
			if (length == 0)
			{
				return 0;
			}

			if (length == 1)
			{
				return 1;
			}

			int k = 0;
			for (int i = 0; i < length; i++)
			{
				if (nums[i] != nums[k])
				{
					k++;
					if (k < i)
					{
						nums[k] = nums[i];
					}
				}
			}
			
			return k + 1;
		}
	}
}