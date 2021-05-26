using System;
using System.Linq;

namespace _08.Bombs2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int[] bombs = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < bombs.Length; i += 2)
            {
                int bombRow = bombs[i];
                int bombCol = bombs[i + 1];
                int damage = matrix[bombRow, bombCol];
                if (damage > 0)
                {
                    for (int row = bombRow - 1; row < bombRow + 2; row++)
                    {
                        for (int col = bombCol - 1; col < bombCol + 2; col++)
                        {
                            if (IsValidCoordinates(row, col, matrix) && matrix[row, col] > 0)
                            {
                                matrix[row, col] -= damage;
                            }
                        }
                    }
                }
            }

            int sum = 0;
            int count = 0;
            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    count++;
                    sum += item;
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidCoordinates(int row, int col, int[,] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
