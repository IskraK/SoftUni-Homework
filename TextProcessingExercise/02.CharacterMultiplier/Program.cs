using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string str1 = input[0];
            string str2 = input[1];

            int sum = 0;

            for (int i = 0; i < Math.Min(str1.Length, str2.Length); i++)
            {
                sum += str1[i] * str2[i];
            }

            string remainingString = string.Empty;

            if (str1.Length > str2.Length)
            {
                remainingString = str1.Substring(str2.Length, str1.Length - str2.Length);
            }
            else
            {
                remainingString = str2.Substring(str1.Length, str2.Length - str1.Length);
            }

            foreach (var symbol in remainingString)
            {
                sum += (int)symbol;
            }

            Console.WriteLine(sum);
        }
    }
}
