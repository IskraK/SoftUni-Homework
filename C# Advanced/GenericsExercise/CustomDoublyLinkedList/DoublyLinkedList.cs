using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        /// <summary>
        /// Брой елементи в списъка
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Първи елемент
        /// </summary>
        public Node<T> Head { get; set; }

        /// <summary>
        /// Последен елемент
        /// </summary>
        public Node<T> Tail { get; set; }

        /// <summary>
        /// Създава празен двойно свързан списък
        /// </summary>
        public DoublyLinkedList()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        /// <summary>
        /// Създава списък с един елемент
        /// </summary>
        /// <param name="value">Стойност на елемента</param>
        public DoublyLinkedList(T value)
            : this()
        {
            Node<T> newNode = new Node<T>()
            {
                Value = value,
                Next = null,
                Previous = null
            };

            Count++;
            Head = Tail = newNode;
        }


        /// <summary>
        /// Създава списък от колекция от елемени
        /// </summary>
        /// <param name="list">Елементи, които да бъдат добавени в списъка</param>
        public DoublyLinkedList(IEnumerable<T> list)
            : this(list.First())
        {
            bool isFirst = true;

            foreach (var item in list)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    Node<T> newNode = new Node<T>()
                    {
                        Value = item,
                        Previous = Tail,
                        Next = null
                    };

                    Tail.Next = newNode;
                    Tail = newNode;
                    Count++;
                }
            }
        }


        /// <summary>
        /// Добавя елемент в началото
        /// </summary>
        /// <param name="element">Елемент за добавяне</param>
        public void AddFirst(T element)
        {
            Node<T> newNode = new Node<T>() { Value = element };

            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
            }

            Count++;
        }

        /// <summary>
        /// Добавя елемент в края на списъка
        /// </summary>
        /// <param name="element">Елемент за добавяне</param>
        public void AddLast(T element)
        {
            Node<T> newNode = new Node<T>() { Value = element };

            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }

            Count++;
        }

        /// <summary>
        /// Премахва елемент в началото
        /// </summary>
        /// <returns>Стойност на премахнатия елемент</returns>
        public T RemoveFirst()
        {
            if (Count > 0)
            {
                T result = Head.Value;
                Node<T> second = Head.Next;
                if (second == null)
                {
                    Tail = null;
                }
                else
                {
                    second.Previous = null;
                }

                Head = second;
                Count--;
                return result;
            }
            throw new InvalidOperationException("The list is empty");
        }

        /// <summary>
        /// Премахва елемент в края
        /// </summary>
        /// <returns>Стойност на премахнатия елемент</returns>
        public T RemoveLast()
        {
            if (Count > 0)
            {
                T result = Tail.Value;
                Node<T> second = Tail.Previous;
                if (second == null)
                {
                    Head = null;
                }
                else
                {
                    second.Next = null;
                }

                Tail = second;
                Count--;
                return result;
            }
            throw new InvalidOperationException("The list is empty");
        }

        /// <summary>
        /// Извършва действие върху всеки елемент на колекцията
        /// </summary>
        /// <param name="action">Действие, което да се изпълни</param>
        public void ForEach(Action<T> action)
        {
            Node<T> currentNode = Head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Превръща списъка в масив
        /// </summary>
        /// <returns>Масив от елементите на списъка</returns>
        public T[] ToArray()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T[] result = new T[Count];
            int index = 0;
            Node<T> currentNode = Head;

            while (currentNode != null)
            {
                result[index] = currentNode.Value;
                index++;
                currentNode = currentNode.Next;
            }
            return result;
        }
    }
}
