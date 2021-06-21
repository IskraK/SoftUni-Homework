using System;

namespace _02.SuperMario3var
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            char[][] jagged = new char[rows][];
            int marioRow = -1;
            int marioCol = -1;

            for (int row = 0; row < rows; row++)
            {
                string currRow = Console.ReadLine();

                jagged[row] = new char[currRow.Length];

                for (int col = 0; col < currRow.Length; col++)
                {
                    jagged[row][col] = currRow[col];

                    if (jagged[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            bool isPrincessReached = false;

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                char direction = char.Parse(input[0]);
                int enemyRow = int.Parse(input[1]);
                int enemyCol = int.Parse(input[2]);

                jagged[enemyRow][enemyCol] = 'B';
                marioLives--;

                int prevRow = marioRow;
                int prevCol = marioCol;

                switch (direction)
                {
                    case 'W':
                        marioRow--;
                        break;
                    case 'S':
                        marioRow++;
                        break;
                    case 'A':
                        marioCol--;
                        break;
                    case 'D':
                        marioCol++;
                        break;
                    default:
                        break;
                }

                if (IsValidCoordinates(marioRow, marioCol, jagged))
                {
                    jagged[prevRow][ prevCol] = '-';

                    if (jagged[marioRow][marioCol] == 'P')
                    {
                        jagged[marioRow][marioCol] = '-';
                        isPrincessReached = true;
                        break;
                    }
                    else if (jagged[marioRow][marioCol] == 'B')
                    {
                        marioLives -= 2;

                        if (marioLives <= 0)
                        {
                            jagged[marioRow][marioCol] = 'X';
                            break;
                        }
                        else
                        {
                            jagged[marioRow][marioCol] = 'M';
                        }
                    }
                }
                else
                {
                    marioRow = prevRow;
                    marioCol = prevCol;
                    jagged[marioRow][marioCol] = 'M';
                }

                if (marioLives <= 0)
                {
                    jagged[marioRow][marioCol] = 'X';
                    break;
                }
            }

            if (isPrincessReached)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            PrintMatrix(jagged);
        }

        //  100/100 

        private static bool IsValidCoordinates(int currRow, int currCol, char[][] jagged)
        {
            return currRow >= 0 && currRow < jagged.GetLength(0) && currCol >= 0 && currCol < jagged[currRow].Length;
        }

        private static void PrintMatrix(char[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
