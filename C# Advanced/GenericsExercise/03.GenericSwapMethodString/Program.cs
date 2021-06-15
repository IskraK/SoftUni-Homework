using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> elements = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                elements.Add(input);
            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap<string>.SwapElements<string>(elements, indexes[0], indexes[1]);
            Swap<string>.Print<string>(elements);
        }
    }
}
