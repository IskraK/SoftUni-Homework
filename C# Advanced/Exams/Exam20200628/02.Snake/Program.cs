using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int snakeRow = -1;
            int snakeCol = -1;
            int burrow1Row = -1;
            int burrow1Col = -1;
            int burrow2Row = -1;
            int burrow2Col = -1;
            int count = 0;
            int food = 0;

            for (int row = 0; row < n; row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (matrix[row,col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (matrix[row,col] == 'B')
                    {
                        burrow1Row = row;
                        burrow1Col = col;
                        count++;
                    }

                    if (matrix[row,col] == 'B' && count == 1)
                    {
                        burrow2Row = row;
                        burrow2Col = col;
                    }
                }
            }

            while (true)
            {
                matrix[snakeRow, snakeCol] = '.';

                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        snakeRow--;
                        break;
                    case "down":
                        snakeRow++;
                        break;
                    case "left":
                        snakeCol--;
                        break;
                    case "right":
                        snakeCol++;
                        break;
                    default:
                        break;
                }

                if (IsValidCoordinates(snakeRow,snakeCol,n))
                {
                    if (matrix[snakeRow,snakeCol] == '*')
                    {
                        food++;
                        matrix[snakeRow, snakeCol] = '.';
                        if (food >= 10)
                        {
                            matrix[snakeRow, snakeCol] = 'S';
                            Console.WriteLine("You won! You fed the snake.");
                            break;
                        }
                    }
                    else if (matrix[snakeRow, snakeCol] == 'B')
                    {
                        if (snakeRow == burrow1Row && snakeCol == burrow1Col)
                        {
                            matrix[burrow1Row, burrow1Col] = '.';
                            snakeRow = burrow2Row;
                            snakeCol = burrow2Col;
                            matrix[burrow2Row, burrow2Col] = 'S';
                        }
                        else if (snakeRow == burrow2Row && snakeCol == burrow2Col)
                        {
                            matrix[burrow2Row, burrow2Col] = '.';
                            snakeRow = burrow1Row;
                            snakeCol = burrow1Col;
                            matrix[burrow1Row, burrow1Col] = 'S';
                        }
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                    }
                }
                else
                {
                    Console.WriteLine("Game over!");
                    break;
                }
            }

            Console.WriteLine($"Food eaten: {food}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidCoordinates(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
