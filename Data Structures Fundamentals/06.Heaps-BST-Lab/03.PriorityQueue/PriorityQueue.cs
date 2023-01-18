namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public PriorityQueue()
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
                Swap(index, parentIndex);
                HeapifyUp(parentIndex);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            T temp = heap[index];
            heap[index] = heap[parentIndex];
            heap[parentIndex] = temp;
        }

        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            return heap[0];
        }

        public T Dequeue()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            T top = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return top;
        }

        private void HeapifyDown(int index)
        {
            if (index > this.Size)
            {
                throw new InvalidOperationException();
            }

            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= this.Size)
            {
                return;
            }

            if (rightChildIndex < this.Size && heap[leftChildIndex].CompareTo(heap[rightChildIndex]) < 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (heap[index].CompareTo(heap[maxChildIndex]) < 0)
            {
                Swap(index, maxChildIndex);
                HeapifyDown(maxChildIndex);
            }
        }
    }
}
