using System;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (var str in input)
            {
                char firstLetter = str[0];
                char lastLetter = str[str.Length-1];

                string numberStr = str.Substring(1, str.Length - 2);
                double number = double.Parse(numberStr);

                if (char.IsUpper(firstLetter))
                {
                    number /= firstLetter - 64;
                }
                else
                {
                    number *= firstLetter - 96;
                }

                if (char.IsUpper(lastLetter))
                {
                    number -= lastLetter - 64;
                }
                else
                {
                    number += lastLetter - 96;
                }

                sum += number;
            }

            Console.WriteLine($"{sum:F2}");
        }
    }
}
