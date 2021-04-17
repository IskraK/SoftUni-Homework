using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> second = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            List<int> result = new List<int>(first.Count + second.Count);

            for (int i = 0; i < Math.Min(first.Count,second.Count); i++)
            {
                result.Add(first[i]);
                result.Add(second[i]);
            }

            int[] range = new int[2];
            if (first.Count > second.Count)
            {
                range = first.TakeLast(2).ToArray();
            }
            else
            {
                range = second.TakeLast(2).ToArray();
            }

            int start = Math.Min(range[0], range[1]);
            int end = Math.Max(range[0], range[1]);

            List<int> finalList = new List<int>(result.Count);

            foreach (int item in result)
            {
                if (item > start && item < end)
                {
                    finalList.Add(item);
                }
            }

            finalList.Sort();
            Console.WriteLine(string.Join(" ",finalList));
        }
    }
}
