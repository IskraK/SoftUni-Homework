using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = currentRow;
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] line = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = line[0];
                int row = int.Parse(line[1]);
                int col = int.Parse(line[2]);
                int value = int.Parse(line[3]);

                if (row < 0 || row >= rows || col < 0 || col >= jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (command == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }

                input = Console.ReadLine();
            }

            foreach (var currRow in jaggedArray)
            {
                Console.WriteLine(string.Join(' ',currRow));
            }
        }
    }
}
