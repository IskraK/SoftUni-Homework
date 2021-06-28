using System;
using System.Linq;

namespace _02Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] jagged = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                jagged[row] = new char[currRow.Length];

                for (int col = 0; col < currRow.Length; col++)
                {
                    jagged[row][col] = currRow[col];

                }
            }

            int countOfCollected = 0;
            int countOfOpponentsTokens = 0;

            string cmdLine = Console.ReadLine();

            while (cmdLine != "Gong")
            {
                string[] cmdArgs = cmdLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                int currRow = int.Parse(cmdArgs[1]);
                int currCol = int.Parse(cmdArgs[2]);

                if (command == "Find")
                {
                    if (IsValidCoordinates(rows, jagged, currRow, currCol))
                    {
                        countOfCollected = CountTokens(jagged, countOfCollected, currRow, currCol);
                    }
                }
                else if (command == "Opponent")
                {
                    string direction = cmdArgs[3];
                    if (IsValidCoordinates(rows, jagged, currRow, currCol))
                    {
                        countOfOpponentsTokens = CountTokens(jagged, countOfOpponentsTokens, currRow, currCol);

                        for (int i = 0; i < 3; i++)
                        {
                            currRow = MoveRow(currRow, direction);
                            currCol = MoveCol(currCol, direction);

                            if (IsValidCoordinates(rows, jagged, currRow, currCol))
                            {
                                countOfOpponentsTokens = CountTokens(jagged, countOfOpponentsTokens, currRow, currCol);
                            }
                        }

                    }
                }

                cmdLine = Console.ReadLine();
            }

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Collected tokens: {countOfCollected}");
            Console.WriteLine($"Opponent's tokens: {countOfOpponentsTokens}");
        }

        private static int CountTokens(char[][] jagged, int countTokens, int row, int col)
        {
            if (jagged[row][col] == 'T')
            {
                countTokens++;
                jagged[row][col] = '-';
            }

            return countTokens;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }
        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        private static bool IsValidCoordinates(int rows, char[][] jagged, int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < jagged[row].Length;
        }
    }
}
