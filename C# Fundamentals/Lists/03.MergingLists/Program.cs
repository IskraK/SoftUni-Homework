using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> firstList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            List<double> secondList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            List<double> resultList = new List<double>(firstList.Count+secondList.Count);

            for (int i = 0; i < Math.Min(firstList.Count,secondList.Count); i++)
            {
                resultList.Add(firstList[i]);
                resultList.Add(secondList[i]);
            }

            for (int i = Math.Min(firstList.Count, secondList.Count); i < Math.Max(firstList.Count, secondList.Count); i++)
            {
                if (firstList.Count > secondList.Count)
                {
                    resultList.Add(firstList[i]);
                }
                else
                {
                    resultList.Add(secondList[i]);
                }
            }

            Console.WriteLine(string.Join(" ",resultList));
        }
    }
}
