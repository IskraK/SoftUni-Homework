using System;

namespace _02.ReVolt4var
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());
            int playerRow = -1;
            int playerCol = -1;
            bool playerWon = false;
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < commandsCount; i++)
            {
                matrix[playerRow, playerCol] = '-';
                string movement = Console.ReadLine();
                playerRow = MoveRow(playerRow, n, movement);
                playerCol = MoveCol(playerCol, n, movement);

                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerRow = MoveRow(playerRow, n, movement);
                    playerCol = MoveCol(playerCol, n, movement);

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        playerWon = true;
                        break;
                    }
                    matrix[playerRow, playerCol] = 'f';
                }
                if (matrix[playerRow, playerCol] == 'T')
                {
                    playerRow = MoveRowBack(playerRow, n, movement);
                    playerCol = MoveColBack(playerCol, n, movement);
                    matrix[playerRow, playerCol] = 'f';
                }

                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    Console.WriteLine("Player won!");
                    playerWon = true;
                    break;
                }
                if (matrix[playerRow, playerCol] == '-')
                {
                    matrix[playerRow, playerCol] = 'f';
                }
            }
            if (!playerWon)
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
        public static int MoveRow(int row, int rows, string movement)
        {
            if (movement == "up")
            {
                row -= 1;
                if (row < 0)
                {
                    row = rows - 1;
                }
            }
            if (movement == "down")
            {
                row += 1;
                if (row >= rows)
                {
                    row = 0;
                }
            }

            return row;
        }

        public static int MoveCol(int col, int cols, string movement)
        {
            if (movement == "left")
            {
                col -= 1;
                if (col < 0)
                {
                    col = cols - 1;
                }
            }
            if (movement == "right")
            {
                col += 1;
                if (col >= cols)
                {
                    col = 0;
                }
            }

            return col;
        }
        public static int MoveRowBack(int row, int rows, string movement)
        {
            if (movement == "up")
            {
                row += 1;
                if (row >= rows)
                {
                    row = 0;
                }

            }
            if (movement == "down")
            {
                row -= 1;
                if (row < 0)
                {
                    row = rows - 1;
                }
            }

            return row;
        }

        public static int MoveColBack(int col, int cols, string movement)
        {
            if (movement == "left")
            {
                col += 1;
                if (col >= cols)
                {
                    col = 0;
                }
            }
            if (movement == "right")
            {
                col -= 1;
                if (col < 0)
                {
                    col = cols - 1;
                }
            }

            return col;
        }
    }
}
