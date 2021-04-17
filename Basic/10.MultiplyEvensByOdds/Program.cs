using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            int sumEvenDigits = GetSumEvenDigits(number);
            int sumOddDigits = GetSumOddDigits(number);
            int result = GetMultipleEvenAndOddSDigitsSums(sumEvenDigits, sumOddDigits);

            Console.WriteLine(result);

        }

        static int GetSumEvenDigits(int number)
        {
            number = Math.Abs(number);
            int digit = number % 10;
            int sumEvens = 0;
            while (number > 0)
            {
                if (digit % 2 == 0)
                {
                    sumEvens += digit;
                }

                number = number / 10;
                digit=number % 10;
            }

            return sumEvens;
        }

        static int GetSumOddDigits(int number)
        {
            number = Math.Abs(number);
            int digit = number % 10;
            int sumOdds = 0;
            while (number > 0)
            {
                if (digit % 2 != 0)
                {
                    sumOdds += digit;
                }
                number = number / 10;
                digit = number % 10;
                
            }

            return sumOdds;
        }

        static int GetMultipleEvenAndOddSDigitsSums(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}
