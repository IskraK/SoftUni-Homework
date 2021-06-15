using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString2var
{
    public class Box<T> where T: IComparable
    {
        private List<T> elements ;
        public Box()
        {
            elements = new List<T>();
        }

        public int GetCountOfGreaterElements<V>(List<T> list, T value)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(value) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
