using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            string mathOperator= Console.ReadLine();
            double number2 = double.Parse(Console.ReadLine());

            double mathResult = Calculation(number1, mathOperator, number2);

            Console.WriteLine(mathResult);
        }

        static double Calculation(double number1, string mathOp, double number2)
        {
            double result = 0;
            switch (mathOp)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    result = number1 / number2;
                    break;
            }

            return result;
        }
    }
}
