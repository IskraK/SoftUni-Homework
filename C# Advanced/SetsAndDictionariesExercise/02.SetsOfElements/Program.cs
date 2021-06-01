using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int sizeFirst = sizes[0];
            int sizeSecond = sizes[1];
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            FillSet(firstSet, sizeFirst);
            FillSet(secondSet, sizeSecond);

            List<int> numbersInBothSets = new List<int>();

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    numbersInBothSets.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ",numbersInBothSets));
        }

        private static HashSet<int> FillSet(HashSet<int> set, int size)
        {
            for (int i = 0; i < size; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }
            return set;
        }
    }
}
