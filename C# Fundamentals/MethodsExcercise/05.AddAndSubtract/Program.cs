using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            int sumFirstAndSecond = GetSum(number1, number2);

            int result = GetSubstraction(sumFirstAndSecond, number3);

            Console.WriteLine(result);
        }

        private static int GetSubstraction(int num1, int num2)
        {
            return num1 - num2;
        }

        private static int GetSum(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}
