using System;

namespace _02.ReVolt3var
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

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                int currRow = playerRow;
                int currCol = playerCol;
                MoveDirection(ref playerRow, ref playerCol, command);

                if (IsValidCoordinates(playerRow, playerCol, n))
                {
                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        MoveDirection(ref playerRow, ref playerCol, command);

                        if (IsValidCoordinates(playerRow, playerCol, n))
                        {
                            if (matrix[playerRow, playerCol] == 'F')
                            {
                                matrix[playerRow, playerCol] = 'f';
                                playerWin = true;
                                break;
                            }
                            continue;
                        }
                        else
                        {
                            MoveBack(n, ref playerRow, ref playerCol);

                            if (matrix[playerRow, playerCol] == 'F')
                            {
                                matrix[playerRow, playerCol] = 'f';
                                playerWin = true;
                                break;
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
                    MoveBack(n, ref playerRow, ref playerCol);
                    matrix[playerRow, playerCol] = 'f';
                }

                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    playerWin = true;
                    break;
                }

                matrix[playerRow, playerCol] = 'f';

                if (command == "")
                {
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

            // 100/100
        }

        private static void MoveBack(int n, ref int row, ref int col)
        {
            if (row == -1)
            {
                row = n - 1;
            }
            else if (row == n)
            {
                row = 0;
            }
            else if (col == -1)
            {
                col = n - 1;
            }
            else if (col == n)
            {
                col = 0;
            }
        }

        private static void MoveDirection(ref int row, ref int col, string command)
        {
            switch (command)
            {
                case "up":
                    row--;
                    break;
                case "down":
                    row++;
                    break;
                case "left":
                    col--;
                    break;
                case "right":
                    col++;
                    break;
                default:
                    break;
            }
        }

        private static bool IsValidCoordinates(int row, int col, int n)
        {
            return row >= 0 && col >= 0 && row < n && col < n;
        }
    }
}
