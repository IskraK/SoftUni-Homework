using System;

namespace _02.SuperMario2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, rows];

            int marioRow = -1;
            int marioCol = -1;

            for (int row = 0; row < rows; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rows; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (matrix[row, col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            bool isPrincessReached = false;

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                char direction = char.Parse(command[0]);
                int enemyRow = int.Parse(command[1]);
                int enemyCol = int.Parse(command[2]);
                matrix[enemyRow, enemyCol] = 'B';
                marioLives--;

                switch (direction)
                {
                    case 'W':
                        if (marioRow - 1 < 0)
                        {
                            continue;
                        }

                        matrix[marioRow, marioCol] = '-';
                        marioRow--;
                        break;
                    case 'S':
                        if (marioRow + 1 >= rows)
                        {
                            continue;
                        }

                        matrix[marioRow, marioCol] = '-';
                        marioRow++;
                        break;
                    case 'A':
                        if (marioCol - 1 < 0)
                        {
                            continue;
                        }

                        matrix[marioRow, marioCol] = '-';
                        marioCol--;
                        break;
                    case 'D':
                        if (marioCol + 1 >= rows)
                        {
                            continue;
                        }

                        matrix[marioRow, marioCol] = '-';
                        marioCol++;
                        break;
                    default:
                        break;
                }

                if (matrix[marioRow, marioCol] == 'P')
                {
                    matrix[marioRow, marioCol] = '-';
                    isPrincessReached = true;
                    break;
                }
                else if (matrix[marioRow, marioCol] == 'B')
                {
                    marioLives -= 2;

                    if (marioLives <= 0)
                    {
                        matrix[marioRow, marioCol] = 'X';
                        break;
                    }
                }

                if (marioLives <= 0)
                {
                    matrix[marioRow, marioCol] = 'X';
                    break;
                }

                matrix[marioRow, marioCol] = 'M';
            }

            if (isPrincessReached)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            PrintMatrix(matrix);
        }

        //  50/100 - В условието е казано правоъгълно поле, а не назъбена матрица !?

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
