namespace Practice
{
    public class NumTree
    {
        public int Start { get; set; }

        public int End { get; set; }

        public NumTree Left { get; set; }

        public NumTree Right { get; set; }

        public int Sum { get; set; }

        public NumTree(
            int start = 0,
            int end = 0,
            NumTree left = null,
            NumTree right = null,
            int sum = 0)
        {
            this.Start = start;
            this.End = end;
            this.Left = left;
            this.Right = right;
            this.Sum = sum;
        }
    }

    public class NumArray
    {
        private int[] _nums;

        private NumTree _numTree;

        public NumArray(int[] nums)
        {
            _nums = nums;
            _numTree = BuildSegmentTree(nums, 0, nums.Length - 1);
        }

        public void Update(int index, int val)
        {
            UpdateSegmentTree(_numTree, index, val);
        }

        public int SumRange(int left, int right)
        {
            return GetSumForRange(_numTree, left, right);
        }

        private NumTree BuildSegmentTree(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            NumTree node = new NumTree(start, end);
            if (start == end)
            {
                node.Sum = nums[start];
            }
            else
            {
                int mid = start + (end - start) / 2;
                node.Left = BuildSegmentTree(nums, start, mid);
                node.Right = BuildSegmentTree(nums, mid + 1, end);
                node.Sum = node.Left.Sum + node.Right.Sum;
            }

            return node;
        }

        private NumTree UpdateSegmentTree(NumTree node, int index, int val)
        {
            if (index < node.Start || index > node.End)
            {
                return node;
            }

            if (node.Start == node.End && node.Start == index)
            {
                node.Sum = val;
                return node;
            }

            int mid = node.Start + (node.End - node.Start) / 2;
            if (index <= mid)
            {
                node.Left = UpdateSegmentTree(node.Left, index, val);
                node.Sum = node.Left.Sum + node.Right.Sum;
            }
            else
            {
                node.Right = UpdateSegmentTree(node.Right, index, val);
                node.Sum = node.Left.Sum + node.Right.Sum;
            }

            return node;
        }

        private int GetSumForRange(NumTree node, int start, int end)
        {
            if (start < node.Start || end > node.End)
            {
                return 0;
            }

            if (node.Start == start && node.End == end)
            {
                return node.Sum;
            }

            int mid = node.Start + (node.End - node.Start) / 2;

            if (end <= mid)
            {
                return GetSumForRange(node.Left, start, end);
            }

            if (start > mid)
            {
                return GetSumForRange(node.Right, start, end);
            }

            return GetSumForRange(node.Left, start, mid) +
                GetSumForRange(node.Right, mid + 1, end);
        }
    }
}