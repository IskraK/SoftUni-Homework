using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string text = Console.ReadLine();

            string newText = string.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = SumDigits(numbers[i]);

                while (sum > text.Length - 1)
                {
                    sum -= text.Length;
                }

                newText += text[sum];
                text=text.Remove(sum,1);
                
                //text = text.Substring(0, sum) + text.Substring(sum + 1);
            }

            Console.WriteLine(newText);
        }

        private static int SumDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                int digit = number % 10;
                sum += digit;
                number = number / 10;
            }

            return sum;
        }
    }
}
