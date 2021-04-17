using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            double result = GetFactorial(number1) / GetFactorial(number2);

            Console.WriteLine($"{result:F2}");
        }

        private static double GetFactorial(int number)
        {
            double factorial = 1;
            if (number == 0)
            {
                factorial = 1;
            }

            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
