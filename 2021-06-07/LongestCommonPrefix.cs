namespace Google
{
	public class Solution
	{
		public string LongestCommonPrefix(string[] strs)
		{
			if (strs.Length == 0)
			{
				return string.Empty;
			}
			
			string result = strs[0];
			for (int i = 1; i < strs.Length; i++)
			{
				result = LongestCommonPrefix(result, strs[i]);
				if (string.IsNullOrEmpty(result))
				{
					return result;
				}
			}

			return result;
		}

		private string LongestCommonPrefix(string left, string right)
		{
			int leftLength = left.Length;
			int rightLength = right.Length;
			
			int smallLength = leftLength < rightLength ? leftLength : rightLength;

			for (int i = smallLength; i > 0; i--)
			{
				string leftSub = left.Substring(0, i);
				string rightSub = right.Substring(0, i);

				if (leftSub == rightSub)
				{
					return leftSub;
				}
			}
			
			return string.Empty;
		}
	}
}
