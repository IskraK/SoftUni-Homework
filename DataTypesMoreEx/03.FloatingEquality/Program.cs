using System;

namespace _03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            const double precision = 0.000001;
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            double difference = Math.Abs(number1 - number2);
            bool result=false;
            if (difference <= precision)
            {
                result = true;
            }
            Console.WriteLine(result);
        }
    }
}
