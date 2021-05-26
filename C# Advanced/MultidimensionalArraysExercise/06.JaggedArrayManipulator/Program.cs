using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArr = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                jaggedArr[row] = currRow;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] = jaggedArr[row][col] * 2;
                        jaggedArr[row + 1][col] = jaggedArr[row + 1][col] * 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] = jaggedArr[row][col] / 2;
                    }

                    for (int col = 0; col < jaggedArr[row + 1].Length; col++)
                    {
                        jaggedArr[row + 1][col] = jaggedArr[row + 1][col] / 2;
                    }
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmd = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 || row >= rows || col < 0 || col >= jaggedArr[row].Length)
                {
                    input = Console.ReadLine();
                    continue;
                }
                else if (cmd == "Add")
                {
                    jaggedArr[row][col] += value;
                }
                else if (cmd == "Subtract")
                {
                    jaggedArr[row][col] -= value;
                }

                input = Console.ReadLine();
            }

            foreach (var currRow in jaggedArr)
            {
                Console.WriteLine(string.Join(' ', currRow));
            }
        }
    }
}
