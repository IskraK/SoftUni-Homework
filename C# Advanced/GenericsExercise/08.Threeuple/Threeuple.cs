using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<T,U,V>
    {
        public Threeuple(T value1,U value2,V value3)
        {
            Item1 = value1;
            Item2 = value2;
            Item3 = value3;
        }
        public T Item1 { get; set; }
        public U Item2 { get; set; }
        public V Item3 { get; set; }
    }
}
