using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
{
    public class Swap<T>
    {
        private List<T> elements;
        public Swap()
        {
            List<T> elements = new List<T>();
        }

        public static void SwapElements<V>(List<T> list,int index1,int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        public static void Print<V>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
    }
}
