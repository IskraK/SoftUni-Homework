using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[0];

            int[,] matrix = new int[rows, cols];

            string input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                int[] currPlant = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int currRow = currPlant[0];
                int currCol = currPlant[1];

                if (IsValidCoordinates(currRow,currCol,matrix))
                {
                    for (int row = 0; row < rows; row++)
                    {
                        matrix[row, currCol]++;
                    }

                    for (int col = 0; col < cols; col++)
                    {
                        matrix[currRow, col]++;
                    }

                    matrix[currRow, currCol]--;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                input = Console.ReadLine();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidCoordinates(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
