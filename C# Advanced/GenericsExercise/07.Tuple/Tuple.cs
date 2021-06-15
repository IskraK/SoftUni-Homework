using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T,V>
    {
        public Tuple(T value1,V value2)
        {
            Item1 = value1;
            Item2 = value2;
        }
        public T Item1 { get; set; }
        public V Item2 { get; set; }
    }
}
