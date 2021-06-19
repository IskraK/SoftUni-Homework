using System;
using System.Linq;

namespace _02.Warships
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

            for (int row = 0; row < size; row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = currRow[col];
                }
            }

            bool player1Wins = false;
            bool player2Wins = false;

            int destroyedShipsByPlayer1 = 0;
            int destroyedShipsByPlayer2 = 0;

            int countShipsPlayer1 = 0;
            int countShipsPlayer2 = 0;

            foreach (var element in field)
            {
                if (element == '<')
                {
                    countShipsPlayer1++;
                }
                else if (element == '>')
                {
                    countShipsPlayer2++;
                }
            }

            for (int i = 0; i < attackCmd.Length; i++)
            {
                if (i % 2 == 0)
                {
                    int[] currAttackByPlayer1 = attackCmd[i]
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    int currAttackedRow = currAttackByPlayer1[0];
                    int currAttackedCol = currAttackByPlayer1[1];

                    if (IsValidCoordinates(currAttackedRow, currAttackedCol, size))
                    {
                        if (field[currAttackedRow, currAttackedCol] == '>')
                        {
                            destroyedShipsByPlayer1++;
                            countShipsPlayer2--;
                            field[currAttackedRow, currAttackedCol] = 'X';
                        }
                        else if (field[currAttackedRow, currAttackedCol] == '#')
                        {
                            field[currAttackedRow, currAttackedCol] = 'X';

                            MinerRangePlayer1(field, ref destroyedShipsByPlayer1, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow, currAttackedCol - 1);
                            MinerRangePlayer1(field, ref destroyedShipsByPlayer1, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow, currAttackedCol + 1);
                            MinerRangePlayer1(field, ref destroyedShipsByPlayer1, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow - 1, currAttackedCol - 1);
                            MinerRangePlayer1(field, ref destroyedShipsByPlayer1, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow - 1, currAttackedCol);
                            MinerRangePlayer1(field, ref destroyedShipsByPlayer1, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow - 1, currAttackedCol + 1);
                            MinerRangePlayer1(field, ref destroyedShipsByPlayer1, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow + 1, currAttackedCol - 1);
                            MinerRangePlayer1(field, ref destroyedShipsByPlayer1, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow + 1, currAttackedCol);
                            MinerRangePlayer1(field, ref destroyedShipsByPlayer1, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow + 1, currAttackedCol + 1);
                        }
                    }

                    if (countShipsPlayer1 > 0 && countShipsPlayer2 <= 0)
                    {
                        player1Wins = true;
                        break;
                    }
                    else if (countShipsPlayer1 <= 0 && countShipsPlayer2 > 0)
                    {
                        player2Wins = true;
                        break;
                    }
                    else if (countShipsPlayer1 <= 0 && countShipsPlayer2 <= 0)
                    {
                        break;
                    }
                }
                else
                {
                    int[] currAttackByPlayer2 = attackCmd[i]
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    int currAttackedRow = currAttackByPlayer2[0];
                    int currAttackedCol = currAttackByPlayer2[1];

                    if (IsValidCoordinates(currAttackedRow, currAttackedCol, size))
                    {
                        if (field[currAttackedRow, currAttackedCol] == '<')
                        {
                            destroyedShipsByPlayer2++;
                            countShipsPlayer1--;
                            field[currAttackedRow, currAttackedCol] = 'X';
                        }
                        else if (field[currAttackedRow, currAttackedCol] == '#')
                        {
                            field[currAttackedRow, currAttackedCol] = 'X';

                            MinerRangePlayer2(field, ref destroyedShipsByPlayer2, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow, currAttackedCol - 1);
                            MinerRangePlayer2(field, ref destroyedShipsByPlayer2, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow, currAttackedCol + 1);
                            MinerRangePlayer2(field, ref destroyedShipsByPlayer2, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow - 1, currAttackedCol -1 );
                            MinerRangePlayer2(field, ref destroyedShipsByPlayer2, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow - 1, currAttackedCol);
                            MinerRangePlayer2(field, ref destroyedShipsByPlayer2, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow - 1, currAttackedCol + 1);
                            MinerRangePlayer2(field, ref destroyedShipsByPlayer2, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow + 1, currAttackedCol - 1);
                            MinerRangePlayer2(field, ref destroyedShipsByPlayer2, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow + 1, currAttackedCol);
                            MinerRangePlayer2(field, ref destroyedShipsByPlayer2, ref countShipsPlayer1, ref countShipsPlayer2, currAttackedRow + 1, currAttackedCol + 1);
                        }
                    }

                    if (countShipsPlayer1 > 0 && countShipsPlayer2 <= 0)
                    {
                        player1Wins = true;
                        break;
                    }
                    else if (countShipsPlayer1 <= 0 && countShipsPlayer2 > 0)
                    {
                        player2Wins = true;
                        break;
                    }
                    else if (countShipsPlayer1 <= 0 && countShipsPlayer2 <= 0)
                    {
                        break;
                    }
                }
            }

            if (player1Wins)
            {
                Console.WriteLine($"Player One has won the game! {destroyedShipsByPlayer1 + destroyedShipsByPlayer2} ships have been sunk in the battle.");
            }
            else if (player2Wins)
            {
                Console.WriteLine($"Player Two has won the game! {destroyedShipsByPlayer2 + destroyedShipsByPlayer1} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {countShipsPlayer1} ships left. Player Two has {countShipsPlayer2} ships left.");
            }
        }

        private static void MinerRangePlayer2(char[,] field, ref int destroyedShipsByPlayer2, ref int countShipsPlayer1, ref int countShipsPlayer2, int row, int col)
        {
            if (IsValidCoordinates(row, col, field.GetLength(0)))
            {
                if (field[row, col] == '<')
                {
                    destroyedShipsByPlayer2++;
                    countShipsPlayer1--;
                }
                else if (field[row, col] == '>')
                {
                    destroyedShipsByPlayer2++;
                    countShipsPlayer2--;
                }
                field[row, col] = 'X';
            }
        }

        private static void MinerRangePlayer1(char[,] field, ref int destroyedShipsByPlayer1, ref int countShipsPlayer1, ref int countShipsPlayer2, int row, int col)
        {
            if (IsValidCoordinates(row, col, field.GetLength(0)))
            {
                if (field[row, col] == '>')
                {
                    destroyedShipsByPlayer1++;
                    countShipsPlayer2--;
                }
                else if (field[row, col] == '<')
                {
                    destroyedShipsByPlayer1++;
                    countShipsPlayer1--;
                }
                field[row, col] = 'X';
            }
        }

        private static bool IsValidCoordinates(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}
