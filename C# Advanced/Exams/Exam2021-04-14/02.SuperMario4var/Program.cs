using System;

namespace _02.SuperMario4var
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
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                char direction = char.Parse(input[0]);
                int enemyRow = int.Parse(input[1]);
                int enemyCol = int.Parse(input[2]);
                jagged[enemyRow][enemyCol] = 'B';
                marioLives--;

                switch (direction)
                {
                    case 'W':
                        if (marioRow-1 < 0)
                        {
                            continue;
                        }
                        jagged[marioRow][marioCol] = '-';
                        marioRow--;
                        break;
                    case 'S':
                        if (marioRow + 1 >= rows)
                        {
                            continue;
                        }
                        jagged[marioRow][marioCol] = '-';
                        marioRow++;
                        break;
                    case 'A':
                        if (marioCol - 1 < 0)
                        {
                            continue;
                        }
                        jagged[marioRow][marioCol] = '-';
                        marioCol--;
                        break;
                    case 'D':
                        if (marioCol + 1 >= jagged[0].Length)
                        {
                            continue;
                        }
                        jagged[marioRow][marioCol] = '-';
                        marioCol++;
                        break;
                    default:
                        break;
                }

                if (jagged[marioRow][marioCol] == 'B')
                {
                    marioLives -= 2;

                    if (marioLives <= 0)
                    {
                        jagged[marioRow][marioCol] = 'X';
                        break;
                    }
                }
                else if (jagged[marioRow][marioCol] == 'P')
                {
                    isPrincessReached = true;
                    jagged[marioRow][marioCol] = '-';
                    break;
                }

                if (marioLives <= 0)
                {
                    jagged[marioRow][marioCol] = 'X';
                    break;
                }

                jagged[marioRow][marioCol] = 'M';
            }

            if (isPrincessReached)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            foreach (var item in jagged)
            {
                Console.WriteLine(item);
            }

            //  100/100
        }
    }
}
