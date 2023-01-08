namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item, null, null);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }

            var oldHead = this.head;
            oldHead.Previous = newNode;
            this.head = newNode;
            this.head.Next = oldHead;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item, null, null);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }

            var oldTail = this.tail;
            oldTail.Next = newNode;
            this.tail = newNode;
            this.tail.Previous = oldTail;
            this.Count++;
        }

        public T GetFirst()
        {
            this.ValidateCollection();

            return this.head.Item;
        }

        public T GetLast()
        {
            this.ValidateCollection();

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            this.ValidateCollection();
            
            var oldHead = this.head;
            this.head = this.head.Next;
            this.Count--;

            return oldHead.Item;
        }

        public T RemoveLast()
        {
            this.ValidateCollection();

            var oldTail = this.tail;
            this.tail = this.tail.Previous;
            this.Count--;

            return oldTail.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateCollection()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}