namespace Google
{
    using System.Collections.Generic;

    public class Solution
    {
        IList<int> stack = new List<int>();

        public int[] NextGreaterElement(int[] nums2)
        {
            int[] greater = new int[nums2.Length];

            int i = 0;
            while (i < nums2.Length)
            {
                if (stack.Count == 0)
                {
                    PushIndex(i);
                    continue;
                }

                if (nums2[i] > nums2[GetIndex()])
                {
                    greater[GetIndex()] = nums2[i];
                    PopIndex();
                    continue;
                }

                PushIndex(i);
                i++;
            }

            for (int j = 0; j < stack.Count; j++)
            {
                greater[stack[j]] = -1;
            }

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int j = 0; j < greater.Length; j++)
            {
                map.Add(nums2[j], greater[j]);
            }

            int[] result = new int[nums1.Length];
            for (int j = 0; j < nums1.Length; j++)
            {
                result[j] = map[nums1[j]];
            }

            return result;
        }

        private void PushIndex(int n)
        {
            stack.Add(n);
        }

        private int GetIndex()
        {
            return stack[stack.Count - 1];
        }

        private void PopIndex()
        {
            stack.RemoveAt(stack.Count - 1);
        }
    }
}