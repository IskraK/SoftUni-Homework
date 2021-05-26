using System;

namespace _09.Miner3var
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] moveCommands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[,] matrix = new string[size, size];

            for (int row = 0; row < size; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == "s")
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            bool isGameOver = false;

            foreach (string command in moveCommands)
            {
                int currentRow = startRow;
                int currentCol = startCol;
                switch (command)
                {
                    case "up":
                        currentRow--;
                        break;
                    case "down":
                        currentRow++;
                        break;
                    case "left":
                        currentCol--;
                        break;
                    case "right":
                        currentCol++;
                        break;
                }

                if (IsValidCoordinates(matrix, currentRow, currentCol))
                {
                    startRow = currentRow;
                    startCol = currentCol;
                    switch (matrix[startRow, startCol])
                    {
                        case "e":
                            Console.WriteLine($"Game over! ({startRow}, {startCol})");
                            isGameOver = true;
                            break;
                        case "c":
                            matrix[startRow, startCol] = "*";
                            break;
                    }
                }
            }

            if (!isGameOver)
            {
                int remainingCoals = 0;
                bool hasCoals = false;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row, col] == "c")
                        {
                            remainingCoals++;
                            hasCoals = true;
                        }
                    }
                }

                if (hasCoals)
                {
                    Console.WriteLine($"{remainingCoals} coals left. ({startRow}, {startCol})");
                }
                else
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                }
            }
        }
        public static bool IsValidCoordinates(string[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
