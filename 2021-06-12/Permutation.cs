namespace Google
{
	using System.Collections.Generic;
	using System.Linq;

	public class Solution
	{
		public IList<IList<int>> Permute(int[] nums)
		{
			IList<IList<int>> result = new List<IList<int>>();
			Permute(nums, new List<int>(), result);

			return result;
		}

		private void Permute(int[] nums, IList<int> perm, IList<IList<int>> result)
		{
			if (nums.Length == 0)
			{
				result.Add(perm.Select(item => item).ToList());
				return;
			}

			for (int i = 0; i < nums.Length; i++)
			{
				perm.Add(nums[i]);

				List<int> newNums = nums.Select(item => item).ToList();
				newNums.RemoveAt(i);
				Permute(newNums.ToArray(), perm, result);

				perm.RemoveAt(perm.Count - 1);
			}
		}
	}
}