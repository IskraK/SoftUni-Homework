﻿using System;
using System.Linq;

namespace _04.Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Lake<int> lake = new Lake<int>(stones);
            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
