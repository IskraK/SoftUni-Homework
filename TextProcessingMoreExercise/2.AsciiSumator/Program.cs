using System;

namespace _2.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char endSymbol = char.Parse(Console.ReadLine());
            string line = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] > firstSymbol && line[i] < endSymbol)
                {
                    sum += line[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
