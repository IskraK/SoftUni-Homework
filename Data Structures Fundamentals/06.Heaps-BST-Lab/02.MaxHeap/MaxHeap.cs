namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public MaxHeap()
        {
            this.heap = new List<T>();
        }

        public int Size { get { return heap.Count; } }

        public void Add(T element)
        {
            heap.Add(element);
            HeapifyUp(heap.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIndex = (index - 1) / 2;

            if (index > 0 && heap[index].CompareTo(heap[parentIndex]) > 0)
            {
                T temp = heap[index];
                heap[index] = heap[parentIndex];
                heap[parentIndex] = temp;

                HeapifyUp(parentIndex);
            }
        }

        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            return heap[0];
        }
    }
}
