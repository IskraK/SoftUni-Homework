using System;
using System.Collections.Generic;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);

            List<string> result = new List<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                string[] elements = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                result.AddRange(elements);
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
