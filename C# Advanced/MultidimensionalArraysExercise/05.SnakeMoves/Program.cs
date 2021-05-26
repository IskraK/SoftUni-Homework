using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            char[,] matrix = new char[rows, cols];

            char[] snake = Console.ReadLine().ToCharArray();
            Queue<char> queueSnake = new Queue<char>(snake);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char symbol = queueSnake.Dequeue();
                    queueSnake.Enqueue(symbol);

                    if (row % 2 == 0)
                    {
                        matrix[row, col] = symbol;
                    }
                    else
                    {
                        matrix[row, cols - 1 - col] = symbol;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
