using System;

namespace _02.ReVolt2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool playerWin = false;

            while (true)
            {
                matrix[playerRow, playerCol] = '-';

                string command = Console.ReadLine();
                countOfCommands--;
                int currRow = playerRow;
                int currCol = playerCol;

                switch (command)
                {
                    case "up":
                        playerRow--;
                        break;
                    case "down":
                        playerRow++;
                        break;
                    case "left":
                        playerCol--;
                        break;
                    case "right":
                        playerCol++;
                        break;
                    default:
                        break;
                }

                if (IsValidCoordinates(playerRow, playerCol, n))
                {
                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        switch (command)
                        {
                            case "up":
                                playerRow--;
                                break;
                            case "down":
                                playerRow++;
                                break;
                            case "left":
                                playerCol--;
                                break;
                            case "right":
                                playerCol++;
                                break;
                            default:
                                break;
                        }

                        if (IsValidCoordinates(playerRow, playerCol, n))
                        {
                            continue;
                        }
                        else
                        {
                            if (playerRow == -1 || playerRow == n)
                            {
                                playerRow = n - 1 - currRow;
                            }
                            else if (playerCol == -1 || playerCol == n)
                            {
                                playerCol = n - 1 - currCol;
                            }
                            matrix[playerRow, playerCol] = 'f';
                        }
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerRow = currRow;
                        playerCol = currCol;
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        playerWin = true;
                        break;
                    }
                }
                else
                {
                    if (playerRow == -1 || playerRow == n)
                    {
                        playerRow = n - 1 - currRow;
                    }
                    else if (playerCol == -1 || playerCol == n)
                    {
                        playerCol = n - 1 - currCol;
                    }
                    matrix[playerRow, playerCol] = 'f';
                }

                if (matrix[playerRow, playerCol] == 'F' || countOfCommands == 0)
                {
                    matrix[playerRow, playerCol] = 'f';
                    break;
                }

                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    playerWin = true;
                    break;
                }
            }

            if (playerWin)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

            // 81/100
        }
        private static bool IsValidCoordinates(int row, int col, int n)
        {
            return row >= 0 && col >= 0 && row < n && col < n;
        }
    }
}
