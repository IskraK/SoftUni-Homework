using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bomb = bombData[0];
            int power = bombData[1];
            int originalCount = numbers.Count;

            for (int i = 0; i < originalCount; i++)
            {
                int idx = numbers.IndexOf(bomb);
                int startIdx = idx - power;
                int endIdx = idx + power;

                if (idx == -1)
                {
                    break;
                }

                if (startIdx < 0)
                {
                    startIdx = 0;
                }

                if (endIdx > numbers.Count-1)
                {
                    endIdx = numbers.Count - 1;
                }

                numbers.RemoveRange(startIdx, endIdx - startIdx+1);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
