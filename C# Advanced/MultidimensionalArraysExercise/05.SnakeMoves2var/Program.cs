using System;
using System.Linq;

namespace _05.SnakeMoves2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();

            int snakeCharIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[snakeCharIndex];
                        snakeCharIndex++;
                        if (snakeCharIndex == snake.Length)
                        {
                            snakeCharIndex = 0;
                        }
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[snakeCharIndex];
                        snakeCharIndex++;
                        if (snakeCharIndex == snake.Length)
                        {
                            snakeCharIndex = 0;
                        }
                    }
                }
            }

            printMatrix(matrix);
        }

        private static void printMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
