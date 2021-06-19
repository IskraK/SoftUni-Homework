using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private readonly List<T> list;

        public CustomStack(params T[] elements) 
        {
            list = new List<T>(elements);
        }

        public void Push(params T[] elements)
        {
            list.AddRange(elements);
        }

        public T Pop()
        {
            if (list.Count == 0)
            {
                throw new IndexOutOfRangeException("No elements");
            }
            T lastElement = list.ElementAt(list.Count - 1);
            list.RemoveAt(list.Count - 1);
            return lastElement;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
