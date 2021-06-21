using System;
using System.Linq;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int MarioLives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, rows];

            int MarioRow = -1;
            int MarioCol = -1;

            for (int row = 0; row < rows; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < rows; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (matrix[row, col] == 'M')
                    {
                        MarioRow = row;
                        MarioCol = col;
                    }
                }
            }

            bool isPrincessReached = false;

            while (true)
            {

                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                char direction = char.Parse(command[0]);
                int enemyRow = int.Parse(command[1]);
                int enemyCol = int.Parse(command[2]);
                matrix[enemyRow, enemyCol] = 'B';
                MarioLives--;

                int prevRow = MarioRow;
                int prevCol = MarioCol;

                switch (direction)
                {
                    case 'W':
                        MarioRow--;
                        break;
                    case 'S':
                        MarioRow++;
                        break;
                    case 'A':
                        MarioCol--;
                        break;
                    case 'D':
                        MarioCol++;
                        break;
                    default:
                        break;
                }

                if (IsValidCoordinates(MarioRow, MarioCol, matrix))
                {
                    matrix[prevRow, prevCol] = '-';

                    if (matrix[MarioRow, MarioCol] == 'P')
                    {
                        matrix[MarioRow, MarioCol] = '-';
                        isPrincessReached = true;
                        break;
                    }
                    else if (matrix[MarioRow, MarioCol] == 'B')
                    {
                        MarioLives -= 2;

                        if (MarioLives <= 0)
                        {
                            matrix[MarioRow, MarioCol] = 'X';
                            break;
                        }
                        else
                        {
                            matrix[MarioRow, MarioCol] = 'M';
                        }
                    }
                }
                else
                {
                    MarioRow = prevRow;
                    MarioCol = prevCol;
                    matrix[MarioRow, MarioCol] = 'M';
                }

                if (MarioLives <= 0)
                {
                    matrix[MarioRow, MarioCol] = 'X';
                    break;
                }
            }

            if (isPrincessReached)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {MarioLives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {MarioRow};{MarioCol}.");
            }

            PrintMatrix(matrix);
        }

        //  50/100 - В условието е казано правоъгълно поле, а не назъбена матрица !? Решенията с jagged array 3var u 4var са 100/100

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidCoordinates(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
