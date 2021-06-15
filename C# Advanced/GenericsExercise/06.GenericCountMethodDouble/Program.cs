using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> elements = new List<double>();

            for (int i = 0; i < n; i++)
            {
                elements.Add(double.Parse(Console.ReadLine()));
            }

            double elementToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(GetCountOfGreaterElements(elements, elementToCompare));
        }
        private static int GetCountOfGreaterElements<T>(List<T> list, T elementToCompare)
            where T : IComparable
        {
            int count = 0;

            foreach (var item in list)
            {
                if (item.CompareTo(elementToCompare) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
