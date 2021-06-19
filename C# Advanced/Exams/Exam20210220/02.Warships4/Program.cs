using System;
using System.Linq;

namespace _02.Warships4
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            string[] attackCmd = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int countShipsPlayer1 = 0;
            int countShipsPlayer2 = 0;

            for (int row = 0; row < size; row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = currRow[col];

                    if (field[row, col] == '<')
                    {
                        countShipsPlayer1++;
                    }
                    else if (field[row, col] == '>')
                    {
                        countShipsPlayer2++;
                    }
                }
            }

            int destroyedShips = 0;

            for (int i = 0; i < attackCmd.Length; i++)
            {
                int[] currAttackCoordinates = attackCmd[i]
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                int currAttackedRow = currAttackCoordinates[0];
                int currAttackedCol = currAttackCoordinates[1];

                if (IsValidCoordinates(currAttackedRow, currAttackedCol, size))
                {
                    if (field[currAttackedRow, currAttackedCol] == '>')
                    {
                        destroyedShips++;
                        countShipsPlayer2--;
                        field[currAttackedRow, currAttackedCol] = 'X';
                    }
                    else if (field[currAttackedRow, currAttackedCol] == '<')
                    {
                        destroyedShips++;
                        countShipsPlayer1--;
                        field[currAttackedRow, currAttackedCol] = 'X';
                    }
                    else if (field[currAttackedRow, currAttackedCol] == '#')
                    {
                        for (int row = currAttackedRow - 1; row <= currAttackedRow + 1; row++)
                        {
                            for (int col = currAttackedCol - 1; col <= currAttackedCol + 1; col++)
                            {
                                if (IsValidCoordinates(row, col, size))
                                {
                                    if (field[row, col] == '<')
                                    {
                                        countShipsPlayer1--;
                                        destroyedShips++;
                                        field[row, col] = 'X';
                                    }
                                    else if (field[row, col] == '>')
                                    {
                                        countShipsPlayer2--;
                                        destroyedShips++;
                                        field[row, col] = 'X';
                                    }
                                }
                            }

                            if (countShipsPlayer1 == 0 || countShipsPlayer2 == 0)
                            {
                                break;
                            }
                        }
                    }
                }

                if (countShipsPlayer1 <= 0)
                {
                    Console.WriteLine($"Player Two has won the game! {destroyedShips} ships have been sunk in the battle.");
                    break;
                }
                else if (countShipsPlayer2 <= 0)
                {
                    Console.WriteLine($"Player One has won the game! {destroyedShips} ships have been sunk in the battle.");
                    break;
                }
            }

            if (countShipsPlayer1 > 0 && countShipsPlayer2 > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {countShipsPlayer1} ships left. Player Two has {countShipsPlayer2} ships left.");
            }
        }

        private static bool IsValidCoordinates(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}
