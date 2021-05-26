using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
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
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < rows; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                    if (matrix[row,col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            bool isPlayerWon = false;
            bool isPlayerDead = false;

            foreach (var direction in directions)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (direction)
                {
                    case 'U':
                        newPlayerRow--;
                        break;
                    case 'D':
                        newPlayerRow++;
                        break;
                    case 'L':
                        newPlayerCol--;
                        break;
                    case 'R':
                        newPlayerCol--;
                        break;
                    default:
                        break;
                }

                matrix[playerRow, playerCol] = '.';

                isPlayerWon = !IsValidCell(newPlayerRow, newPlayerCol, rows, cols);

                if (!isPlayerWon)
                {
                    if (matrix[newPlayerRow,newPlayerCol] == '.')
                    {
                        matrix[newPlayerRow, newPlayerCol] = 'P';
                    }
                    else if (matrix[newPlayerRow, newPlayerCol] == 'B')
                    {
                        isPlayerDead = true;
                    }

                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }

                List<int[]> currBunnyIndex = GetBunnyIndexes(matrix);
                SpreadBuunies(currBunnyIndex, matrix);

                if (matrix[playerRow,playerCol] == 'B')
                {
                    isPlayerDead = true;
                }

                if (isPlayerDead || isPlayerWon)
                {
                    break;
                }
            }

            PrintMatrix(matrix);

            string result = String.Empty;
            if (isPlayerWon)
            {
                result += "won: ";
            }
            else
            {
                result += "dead: ";
            }
            result += $"{playerRow} {playerCol}";

            Console.WriteLine(result);
        }

        private static void PrintMatrix(char[,] matrix)
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

        private static void SpreadBuunies(List<int[]> currBunnyIndex, char[,] matrix)
        {
            foreach (int[] currBunny in currBunnyIndex)
            {
                int bunnyRow = currBunny[0];
                int bunnyCol = currBunny[1];

                if (IsValidCell(bunnyRow - 1, bunnyCol, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[bunnyRow - 1, bunnyCol] = 'B';
                }
                if (IsValidCell(bunnyRow + 1, bunnyCol, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[bunnyRow + 1, bunnyCol] = 'B';
                }
                if (IsValidCell(bunnyRow, bunnyCol - 1, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[bunnyRow, bunnyCol -1] = 'B';
                }
                if (IsValidCell(bunnyRow, bunnyCol + 1, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[bunnyRow, bunnyCol + 1] = 'B';
                }
            }
        }

        private static List<int[]> GetBunnyIndexes(char[,] matrix)
        {
            List<int[]> bunnies = new List<int[]>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == 'B')
                    {
                        bunnies.Add(new[] { row, col });
                    }
                }
            }
            return bunnies;
        }

        private static bool IsValidCell(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}
