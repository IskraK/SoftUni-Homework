using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int beeRow = -1;
            int beeCol = -1;
            int bonusRow = -1;
            int bonusCol = -1;

            for (int row = 0; row < n; row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (matrix[row,col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }

                    if (matrix[row,col] == 'O')
                    {
                        bonusRow = row;
                        bonusCol = col;
                    }
                }
            }

            int pollinatedFlowers = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    matrix[beeRow, beeCol] = 'B';
                    break;
                }

                matrix[beeRow, beeCol] = '.';
                MoveDirection(ref beeRow, ref beeCol, command);

                if (!IsValidCoordinates(beeRow, beeCol, n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                else
                {
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        pollinatedFlowers++;
                        matrix[beeRow, beeCol] = '.';
                    }
                    else if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        MoveDirection(ref beeRow,ref beeCol, command);

                        if (IsValidCoordinates(beeRow,beeCol,n))
                        {
                            if (matrix[beeRow, beeCol] == 'f')
                            {
                                pollinatedFlowers++;
                                matrix[beeRow, beeCol] = '.';
                            }
                        }
                        else
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                    }
                }
            }

            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-pollinatedFlowers} flowers more");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveDirection(ref int beeRow, ref int beeCol, string command)
        {
            switch (command)
            {
                case "up":
                    beeRow--;
                    break;
                case "down":
                    beeRow++;
                    break;
                case "left":
                    beeCol--;
                    break;
                case "right":
                    beeCol++;
                    break;
                default:
                    break;
            }
        }

        private static bool IsValidCoordinates(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
