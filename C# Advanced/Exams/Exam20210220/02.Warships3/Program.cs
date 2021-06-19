using System;
using System.Linq;

namespace _02.Warships3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            int shipsPlayer1 = 0;
            int shipsPlayer2 = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = char.Parse(inputs[col]);

                    if (matrix[row, col] == '<')
                    {
                        shipsPlayer1++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        shipsPlayer2++;
                    }
                }
            }

            int countDestroyedShips = 0;
            bool isWon = false;

            for (int i = 0; i < input.Length; i++)
            {
                int[] cordinates = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int rowIndex = cordinates[0];
                int colIndex = cordinates[1];

                if (rowIndex >= 0 && rowIndex < matrix.GetLength(0) &&
                    colIndex >= 0 && colIndex < matrix.GetLength(1))
                {
                    if (matrix[rowIndex, colIndex] == '#')
                    {
                        (matrix, shipsPlayer1, shipsPlayer2, countDestroyedShips, isWon) = Bomb(matrix, rowIndex, colIndex,
                            shipsPlayer1, shipsPlayer2, countDestroyedShips, isWon);
                    }

                    if (matrix[rowIndex, colIndex] == '>')
                    {
                        shipsPlayer2--;
                        countDestroyedShips++;
                        matrix[rowIndex, colIndex] = 'X';
                    }

                    if (matrix[rowIndex, colIndex] == '<')
                    {
                        shipsPlayer1--;
                        countDestroyedShips++;
                        matrix[rowIndex, colIndex] = 'X';
                    }

                    if (shipsPlayer1 == 0)
                    {
                        isWon = true;
                        Console.WriteLine($"Player Two has won the game! {countDestroyedShips} ships have been sunk in the battle.");
                        break;
                    }
                    else if (shipsPlayer2 == 0)
                    {
                        isWon = true;
                        Console.WriteLine($"Player One has won the game! {countDestroyedShips} ships have been sunk in the battle.");
                        break;
                    }
                }
            }

            if (!isWon && shipsPlayer1 > 0 && shipsPlayer2 > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {shipsPlayer1} ships left. Player Two has {shipsPlayer2} ships left.");
            }
        }
        public static (char[,], int, int, int, bool) Bomb(char[,] matrix, int rowIndex, int colIndex, int shipsPlayer1, int shipsPlayer2, int countDestroyedShips, bool isWin)
        {
            for (int row = rowIndex - 1; row <= rowIndex + 1; row++)
            {
                for (int col = colIndex - 1; col <= colIndex + 1; col++)
                {
                    if (row >= 0 && row < matrix.GetLength(0) &&
                        col >= 0 && col < matrix.GetLength(1))
                    {
                        if (matrix[row, col] == '>')
                        {
                            shipsPlayer2--;
                            countDestroyedShips++;
                            matrix[row, col] = 'X';
                        }
                        else if (matrix[row, col] == '<')
                        {
                            shipsPlayer1--;
                            countDestroyedShips++;
                            matrix[row, col] = 'X';
                        }
                    }
                }

                if (shipsPlayer1 == 0)
                {
                    isWin = true;
                    break;
                }
                else if (shipsPlayer2 == 0)
                {
                    isWin = true;
                    break;
                }
            }
            return (matrix, shipsPlayer1, shipsPlayer2, countDestroyedShips, isWin);
        }
    }
}
