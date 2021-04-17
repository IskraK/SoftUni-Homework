using System;

namespace _05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            double number3 = double.Parse(Console.ReadLine());

            string resultSign = GetMultiplicationSign(number1, number2, number3);

            Console.WriteLine(resultSign);
        }

        private static string GetMultiplicationSign(double number1, double number2, double number3)
        {
            string sign = "";

            if (number1 > 0 && number2 > 0 && number3 > 0 
                || number1 < 0 && number2 < 0 && number3 > 0
                || number1 < 0 && number3 < 0 && number2 > 0
                || number1 > 0 && number2 < 0 && number3 < 0)
            {
                sign = "positive";
            }
            else if (number1 == 0 || number2 == 0 || number3 == 0)
            {
                sign = "zero";
            }
            else
            {
                sign = "negative";
            }

            return sign;
        }
    }
}
