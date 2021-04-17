using System;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commandLine = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = commandLine[0];

                switch (command)
                {
                    case "swap":
                        int idx1 = int.Parse(commandLine[1]);
                        int idx2 = int.Parse(commandLine[2]);
                        int temp = numbers[idx1];
                        numbers[idx1] = numbers[idx2];
                        numbers[idx2] = temp;
                        break;
                    case "multiply":
                         idx1 = int.Parse(commandLine[1]);
                         idx2 = int.Parse(commandLine[2]);
                        numbers[idx1] *= numbers[idx2];
                        break;
                    case "decrease":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] -= 1;
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
