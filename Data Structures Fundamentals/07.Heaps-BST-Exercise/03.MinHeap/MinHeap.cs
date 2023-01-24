namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            this.ValidateIfEmpty();
            T element = this.elements[0];
            this.Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);
            this.HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int parentIndex)
        {
            var smallerChildIndex = parentIndex * 2 + 1;
            smallerChildIndex = this.FindSmallerChildIndex(parentIndex * 2 + 1, parentIndex * 2 + 2);

            while (smallerChildIndex != -1 && IsGreater(parentIndex, smallerChildIndex))
            {
                this.Swap(parentIndex, smallerChildIndex);
                parentIndex = smallerChildIndex;
                smallerChildIndex = this.FindSmallerChildIndex(parentIndex * 2 + 1, parentIndex * 2 + 2);
            }
        }

        private int FindSmallerChildIndex(int leftChildIndex, int rightChildIndex)
        {
            if (leftChildIndex >= this.Size)
            {
                return -1;
            }

            if (rightChildIndex >= this.Size)
            {
                return leftChildIndex;
            }

            return IsGreater(leftChildIndex, rightChildIndex) ? rightChildIndex : leftChildIndex;
        }

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.Size - 1);
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;
            while (index > 0 && IsGreater(parentIndex, index))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;
        }

        public T Peek()
        {
            this.ValidateIfEmpty();
            return this.elements[0];
        }

        private void ValidateIfEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return this.elements[index]
                .CompareTo(this.elements[parentIndex]) > 0;
        }
    }
}
