namespace Google
{
	public class Solution
	{
		public IList<IList<int>> PermuteUnique(int[] nums)
		{
			Array.Sort(nums);
			
			IList<IList<int>> result = new List<IList<int>>();
			PermuteUnique(nums, new List<int>(), result);

			return result;
		}

		private void PermuteUnique(int[] nums, IList<int> perm, IList<IList<int>> result)
		{
			if (nums.Length == 0)
			{
				result.Add(perm.Select(item => item).ToList());
				return;
			}

			for (int i = 0; i < nums.Length; i++)
			{
				if (i == 0 || (nums[i] != nums[i - 1]))
				{
					perm.Add(nums[i]);
					
					List<int> newNums = nums.Select(item => item).ToList();
					newNums.RemoveAt(i);
					PermuteUnique(newNums.ToArray(), perm, result);

					perm.RemoveAt(perm.Count - 1);
				}
			}
		}
	}
}