﻿using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> validator = (name, value) =>
                name.ToCharArray()
                .Select(currChar => (int)currChar)
                .Sum() >= number;

            Func<string[], int, Func<string, int, bool>, string> foundName = (collection, value, func) =>
                   collection.FirstOrDefault(n => func(n, value));

            Console.WriteLine(foundName(names,number,validator));
        }
    }
}
