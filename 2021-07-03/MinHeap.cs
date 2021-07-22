namespace Google
{
    using System;
    using System.Collections.Generic;

    public class MinHeap
    {
        private const int Default = int.MaxValue;

        // Heap starts from index = 1.
        private readonly IList<int> heap;

        private int last;

        public MinHeap()
        {
            heap = new List<int> { Default };
            last = 0;
        }

        public void Add(int num)
        {
            Allocate();

            int position = GetEmptyPosition(1);
            last = position;
            heap[position] = num;

            AdjustBottomUp(position);
        }

        public int Top()
        {
            if (heap.Count < 2)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            return heap[1];
        }

        public int Remove()
        {
            if (heap.Count < 2)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            int top = heap[1];
            heap[1] = heap[last];
            heap[last] = Default;

            AdjustTopDown(1);

            return top;
        }

        private void Allocate()
        {
            heap.Add(Default);
            heap.Add(Default);
        }

        private int GetEmptyPosition(int i)
        {
            if (i >= heap.Count || heap[i] == Default)
            {
                return i;
            }

            return Math.Min(
                GetEmptyPosition(i * 2),
                GetEmptyPosition(i * 2 + 1));
        }

        private void AdjustBottomUp(int position)
        {
            if (position <= 1)
            {
                return;
            }

            int parent = position / 2;
            if (heap[position] < heap[parent])
            {
                int temp = heap[parent];
                heap[parent] = heap[position];
                heap[position] = temp;

                AdjustBottomUp(parent);
            }
        }

        private void AdjustTopDown(int position)
        {
            if (position >= last)
            {
                return;
            }

            int left = position * 2;
            if (heap[position] > heap[left])
            {
                int temp = heap[position];
                heap[position] = heap[left];
                heap[left] = temp;

                AdjustTopDown(left);
            }

            int right = position * 2 + 1;
            if (heap[position] > heap[right])
            {
                int temp = heap[position];
                heap[position] = heap[right];
                heap[right] = temp;

                AdjustTopDown(right);
            }
        }
    }
}