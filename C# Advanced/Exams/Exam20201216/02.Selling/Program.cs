using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            const int neededMoney = 50;
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int sellerRow = -1;
            int sellerCol = -1;
            int firstPillarRow = -1;
            int firstPillarCol = -1;
            int secondPillarRow = -1;
            int secondPillarCol = -1;
            int countPillar = 1;

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (matrix[row, col] == 'S')
                    {
                        sellerRow = row;
                        sellerCol = col;
                    }

                    if (matrix[row, col] == 'O' && countPillar == 1)
                    {
                        firstPillarRow = row;
                        firstPillarCol = col;
                        countPillar++;
                    }

                    if (matrix[row, col] == 'O' && countPillar == 2)
                    {
                        secondPillarRow = row;
                        secondPillarCol = col;
                    }
                }
            }

            int money = 0;

            while (IsValidCoordinates(sellerRow,sellerCol,n))
            {
                string command = Console.ReadLine();
                matrix[sellerRow, sellerCol] = '-';

                switch (command)
                {
                    case "up":
                        sellerRow--;
                        break;
                    case "down":
                        sellerRow++;
                        break;
                    case "left":
                        sellerCol--;
                        break;
                    case "right":
                        sellerCol++;
                        break;
                    default:
                        break;
                }

                if (IsValidCoordinates(sellerRow, sellerCol, n))
                {
                    if (matrix[sellerRow, sellerCol] == 'O')
                    {
                        if (sellerRow == firstPillarRow && sellerCol == firstPillarCol)
                        {

                            matrix[firstPillarRow, firstPillarCol] = '-';
                            sellerRow = secondPillarRow;
                            sellerCol = secondPillarCol;
                        }
                        else if (sellerRow == secondPillarRow && sellerCol == secondPillarCol)
                        {
                            matrix[secondPillarRow, secondPillarCol] = '-';
                            sellerRow = firstPillarRow;
                            sellerCol = firstPillarCol;
                        }
                        matrix[sellerRow, sellerCol] = 'S';
                    }
                    else if (char.IsDigit(matrix[sellerRow, sellerCol]))
                    {
                        money += int.Parse(matrix[sellerRow, sellerCol].ToString());
                        matrix[sellerRow, sellerCol] = '-';
                        if (money >= neededMoney)
                        {
                            matrix[sellerRow, sellerCol] = 'S';
                            Console.WriteLine("Good news! You succeeded in collecting enough money!");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                }

                if (money >= neededMoney)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    break;
                }
            }

            Console.WriteLine($"Money: {money}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidCoordinates(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
