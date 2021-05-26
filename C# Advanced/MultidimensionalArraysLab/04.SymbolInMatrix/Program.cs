using System;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool symbolExist = false;
            int symbolRow = 0;
            int symbolCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col] == symbol)
                    {
                        symbolExist = true;
                        symbolRow = row;
                        symbolCol = col;
                        break;
                    }
                }

                if (symbolExist)
                {
                    break;
                }
            }

            if (symbolExist)
            {
                Console.WriteLine($"({symbolRow}, {symbolCol})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }
    }
}
