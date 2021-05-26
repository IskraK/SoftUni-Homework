using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];

            for (int row = 0; row < size; row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currRow[col].ToString();
                }
            }

            int currKnightsInDanger = 0;
            int maxKnightsInDanger = -1;
            int removedKnights = 0;
            int maxRow = 0;
            int maxCol = 0;

            while (true)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row, col] == "K")
                        {
                            if (IsValidCoordinates(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == "K")
                            {
                                currKnightsInDanger++;
                            }

                            if (IsValidCoordinates(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == "K")
                            {
                                currKnightsInDanger++;
                            }

                            if (IsValidCoordinates(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == "K")
                            {
                                currKnightsInDanger++;

                            }

                            if (IsValidCoordinates(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == "K")
                            {
                                currKnightsInDanger++;
                            }

                            if (IsValidCoordinates(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == "K")
                            {
                                currKnightsInDanger++;
                            }

                            if (IsValidCoordinates(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == "K")
                            {
                                currKnightsInDanger++;
                            }

                            if (IsValidCoordinates(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == "K")
                            {
                                currKnightsInDanger++;
                            }

                            if (IsValidCoordinates(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == "K")
                            {
                                currKnightsInDanger++;
                            }
                        }

                        if (currKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currKnightsInDanger;
                            maxRow = row;
                            maxCol = col;
                        }
                        currKnightsInDanger = 0;
                    }
                }
                if (maxKnightsInDanger != 0)
                {
                    matrix[maxRow, maxCol] = "0";
                    removedKnights++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    return;
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
