using System;
using System.Linq;

namespace _01.SumMatrixElementsvar2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadArrayFromConsole();
            int rows = sizes[0];
            int cols = sizes[1];
            int sum = 0;

            Console.WriteLine(rows);
            Console.WriteLine(cols);

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currRow = ReadArrayFromConsole();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                    sum += matrix[row, col];
                }
            }

            Console.WriteLine(sum);
        }

        public static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
