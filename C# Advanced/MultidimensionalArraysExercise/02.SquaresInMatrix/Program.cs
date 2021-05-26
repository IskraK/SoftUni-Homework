using System;
using System.Linq;

namespace _02.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes =ParseArrayFromConsole();
            int rows = sizes[0];
            int cols = sizes[1];
            string[,] matrix =new string[rows,cols] ;

            for (int row = 0; row < rows; row++)
            {
                string[] currRow = ReadArrayFromConsole();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int countEqualMatrix = 0;

            for (int row = 0; row < rows -1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    string element = matrix[row, col];
                    if (element == matrix[row,col+1] && element == matrix[row+1, col] && element == matrix[row+1, col + 1])
                    {
                        countEqualMatrix++;
                    }
                }
            }

            Console.WriteLine(countEqualMatrix);
        }

        private static string[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }

        private static int[] ParseArrayFromConsole()
        {
           return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
