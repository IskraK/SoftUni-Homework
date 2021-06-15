using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{/// <summary>
/// Елемент от двойно свързан списък
/// </summary>
    public class Node<V>

    {/// <summary>
    /// Стойност на елемента
    /// </summary>
        public V Value { get; set; }

        /// <summary>
        /// Предишен елемент
        /// </summary>
        public Node<V> Previous { get; set; }

        /// <summary>
        /// Следващ елемент
        /// </summary>
        public Node<V> Next { get; set; }
    }
}
