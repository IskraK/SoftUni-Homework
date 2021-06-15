using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString2var
{
    public class Program
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
            Box<string> box = new Box<string>();
            Console.WriteLine(box.GetCountOfGreaterElements<string>(elements, elementToCompare));
        }
    }
}
