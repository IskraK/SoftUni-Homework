using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> elements = new List<string>();

            for (int i = 0; i < n; i++)
            {
                elements.Add(Console.ReadLine());
            }

            string elementToCompare = Console.ReadLine();
            Console.WriteLine(GetCountOfGreaterElements(elements, elementToCompare)); 
        }

        private static int GetCountOfGreaterElements<T>(List<T> list, T elementToCompare)
            where T:IComparable
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
