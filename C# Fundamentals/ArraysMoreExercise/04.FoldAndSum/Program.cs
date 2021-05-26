using System;
using System.Linq;

namespace _04.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] upperRow = new int[arr.Length / 2];
            int[] arrFinal = new int[arr.Length / 2];
            int counter = 0;

            for (int i = arr.Length/4 -1; i >= 0; i--)
            {
                upperRow[counter] = arr[i];
                counter++;
            }

            for (int i = arr.Length-1; i >= arr.Length*3/4; i--)
            {
                upperRow[counter] = arr[i];
                counter++;
            }

            for (int i = 0; i < upperRow.Length; i++)
            {
                arrFinal[i] = upperRow[i] + arr[i+arr.Length/4];
                Console.Write($"{arrFinal[i]} ");
            }
        }
    }
}
