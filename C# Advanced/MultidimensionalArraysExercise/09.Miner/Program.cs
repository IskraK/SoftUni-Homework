using System;

namespace _09.Miner
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

            int countCoals = 0;
            int currRow = startRow;
            int currCol = startCol;
            bool isGameOver = false;

            for (int i = 0; i < moveCommands.Length; i++)
            {
                string command = moveCommands[i];

                switch (command)
                {
                    case "left":
                        currCol = currCol - 1;

                        if (IsValidCoordinates(matrix, currRow, currCol))
                        {
                            if (matrix[currRow, currCol] == "c")
                            {
                                countCoals++;
                                matrix[currRow, currCol] = "*";
                            }
                            else if (matrix[currRow, currCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                isGameOver = true;
                                break;
                            }
                            else if (currCol == 0 && moveCommands[i + 1] == "left" && i < moveCommands.Length - 2)
                            {
                                continue;
                            }
                            else if (currCol == size - 1 && moveCommands[i + 1] == "right" && i < moveCommands.Length - 2)
                            {
                                continue;
                            }
                            else if (currRow == 0 && moveCommands[i + 1] == "up" && i < moveCommands.Length - 2)
                            {
                                continue;
                            }
                            else if (currRow == size - 1 && moveCommands[i + 1] == "down" && i < moveCommands.Length - 2)
                            {
                                continue;
                            }
                        }
                        break;
                    case "right":
                        currCol = currCol + 1;

                        if (IsValidCoordinates(matrix, currRow, currCol))
                        {
                            if (matrix[currRow, currCol] == "c")
                            {
                                countCoals++;
                                matrix[currRow, currCol] = "*";
                            }
                            else if (matrix[currRow, currCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                isGameOver = true;
                                break;
                            }
                            else if (currCol == 0 && moveCommands[i + 1] == "left" && i <= moveCommands.Length - 2)
                            {
                                continue;
                            }
                            else if (currCol == size - 1 && moveCommands[i + 1] == "right" && i <= moveCommands.Length - 2)
                            {
                                continue;
                            }
                            else if (currRow == 0 && moveCommands[i + 1] == "up" && i <= moveCommands.Length - 2)
                            {
                                continue;
                            }
                            else if (currRow == size - 1 && moveCommands[i + 1] == "down" && i <= moveCommands.Length - 2)
                            {
                                continue;
                            }
                        }
                        break;
                    case "up":
                        currRow = currRow - 1;

                        if (IsValidCoordinates(matrix, currRow, currCol))
                        {
                            if (matrix[currRow, currCol] == "c")
                            {
                                countCoals++;
                                matrix[currRow, currCol] = "*";
                            }
                            else if (matrix[currRow, currCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                isGameOver = true;
                                break;
                            }
                            else if (currCol == 0 && moveCommands[i + 1] == "left" && i <= moveCommands.Length - 2)
                            {
                                continue;
                            }
                            else if (currCol == size - 1 && moveCommands[i + 1] == "right" && i <= moveCommands.Length - 2)
                            {
                                continue;
                            }
                            else if (currRow == 0 && moveCommands[i + 1] == "up" && i <= moveCommands.Length - 2)
                            {
                                continue;
                            }
                            else if (currRow == size - 1 && moveCommands[i + 1] == "down" && i <= moveCommands.Length - 2)
                            {
                                continue;
                            }
                        }
                        break;
                    case "down":
                        currRow = currRow + 1;

                        if (IsValidCoordinates(matrix, currRow, currCol))
                        {
                            if (matrix[currRow, currCol] == "c")
                            {
                                countCoals++;
                                matrix[currRow, currCol] = "*";
                            }
                            else if (matrix[currRow, currCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                isGameOver = true;
                                break;
                            }
                            else if (currCol == 0 && moveCommands[i + 1] == "left" && i <= moveCommands.Length - 2)
                            {
                                continue;
                            }
                            else if (currCol == size - 1 && moveCommands[i + 1] == "right" && i <= moveCommands.Length - 2)
                            {
                                continue;
                            }
                            else if (currRow == 0 && moveCommands[i + 1] == "up" && i <= moveCommands.Length - 2)
                            {
                                continue;
                            }
                            else if (currRow == size - 1 && moveCommands[i + 1] == "down" && i <= moveCommands.Length - 2)
                            {
                                continue;
                            }
                        }
                        break;
                    default:
                        break;
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
                    Console.WriteLine($"{remainingCoals} coals left. ({currRow}, {currCol})");
                }
                else
                {
                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
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
