using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomDoublyLinkedList
{
    /// <summary>
    /// Двойно свързан списък
    /// </summary>
    public class CustomLinkedList
    {
        /// <summary>
        /// Брой елементи в списъка
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Първи елемент
        /// </summary>
        public Node Head { get; set; }

        /// <summary>
        /// Последен елемент
        /// </summary>
        public Node Tail { get; set; }

        /// <summary>
        /// Създава празен двойно свързан списък
        /// </summary>
        public CustomLinkedList()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        /// <summary>
        /// Създава списък с един елемент
        /// </summary>
        /// <param name="value">Стойност на елемента</param>
        public CustomLinkedList(int value)
            : this()
        {
            Node newNode = new Node()
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
        public CustomLinkedList(IEnumerable<int> list)
            :this(list.First())
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
                    Node newNode = new Node()
                    {
                        Value=item,
                        Previous=Tail,
                        Next=null
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
        public void AddFirst(int element)
        {
            Node newNode = new Node() { Value = element };

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
        public void AddLast(int element)
        {
            Node newNode = new Node() { Value = element };

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
        public int RemoveFirst()
        {
            if (Count > 0)
            {
                int result = Head.Value;
                Node second = Head.Next;
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
            throw new IndexOutOfRangeException("Empty list.");
        }

        /// <summary>
        /// Премахва елемент в края
        /// </summary>
        /// <returns>Стойност на премахнатия елемент</returns>
        public int RemoveLast()
        {
            if (Count > 0)
            {
                int result = Tail.Value;
                Node second = Tail.Previous;
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
            throw new IndexOutOfRangeException("Empty list.");
        }

        /// <summary>
        /// Извършва действие върху всеки елемент на колекцията
        /// </summary>
        /// <param name="action">Действие, което да се изпълни</param>
        public void Foreach(Action<int> action)
        {
            Node currentNode = Head;

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
        public int[] ToArray()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("Empty list.");
            }

            int[] result = new int[Count];
            int index = 0;
            Node currentNode = Head;

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
