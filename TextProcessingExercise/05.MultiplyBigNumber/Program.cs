using System;
using System.Numerics;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number1 = BigInteger.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            string multiplyNumbers = (number1 * number2).ToString();
            //BigInteger multiplyNumbers = number1 * number2;

            Console.WriteLine(multiplyNumbers);
        }
    }
}
