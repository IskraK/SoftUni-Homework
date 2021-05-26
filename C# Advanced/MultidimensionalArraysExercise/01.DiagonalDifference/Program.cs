using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int primarySum = 0;
            int secondarySum = 0;

            for (int row = 0; row < n; row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (row == col)
                    {
                        primarySum += matrix[row, col];
                    }

                    if (row + col == n-1)
                    {
                        secondarySum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(primarySum-secondarySum));
        }
    }
}
