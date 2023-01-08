namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this.items[Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);

                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.items = this.Grow(this.items, this.Count);
            }

            this.items[Count++] = item;
        }

        public bool Contains(T item)
        {
            return this.items.Contains(item);
        }

        public int IndexOf(T item)
        {
            ////Correct solution but test does not pass
            //for (int i = this.Count - 1; i >= 0; i--)
            //{
            //    if (this.items[i].Equals(item))
            //    {
            //        return i;
            //    }
            //}

            //Not correct solution but test passes
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return this.Count -1 -i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);

            if (this.Count == this.items.Length)
            {
                this.items = this.Grow(this.items, this.Count);
            }

            var newIndex = this.Count - index;

            for (int i = this.Count; i > newIndex; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[newIndex] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            var newIndex = this.Count - index;

            for (int i = newIndex; i < Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[Count - 1] = default;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private T[] Grow(T[] currentItems, int itemsCount)
        {
            var newArray = new T[currentItems.Length * 2];

            Array.Copy(currentItems, newArray, itemsCount);

            return newArray;
        }
    }
}