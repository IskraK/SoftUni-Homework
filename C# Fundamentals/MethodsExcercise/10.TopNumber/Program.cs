using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool IsTopNumber(int number)
        {
            return IsDivisible(number, 8) && ContainsOddDigits(number);
        }

        private static bool ContainsOddDigits(int number)
        {
            while (number != 0)
            {
                int digit = number % 10;

                if (digit % 2 !=0)
                {
                    return true;
                }

                number = number / 10;
            }

            return false;
        }

        private static bool IsDivisible(int number, int divider)
        {
            int sumOfDigits = 0;

            while (number != 0)
            {
                int digit = number % 10;
                sumOfDigits += digit;
                number = number / 10;
            }

            return sumOfDigits % divider == 0;
        }
    }
}
