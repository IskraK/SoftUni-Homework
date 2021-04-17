using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bestSize = 0;
            int bestSequenceNumber = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int size = 1;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        size += 1;
                    }
                    else
                    {
                        break;
                    }
                }
                if (size > bestSize)
                {
                    bestSize = size;
                    bestSequenceNumber = arr[i];
                }
            }

            for (int i = 0; i < bestSize; i++)
            {
                Console.Write($"{bestSequenceNumber} ");
            }
            Console.WriteLine();
        }
    }
}
