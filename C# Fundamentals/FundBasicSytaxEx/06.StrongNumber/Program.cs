using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int realNumber = number;
            string num = number.ToString();
            int digits = num.Length;
            int sumFactDigits = 0;
            for (int i = 0; i < digits; i++)
            {
                int n = number % 10;
                int fact;
                if (n == 0)
                {
                    fact = 1;
                }
                else
                {
                    fact = n;
                }
                for (int j = n - 1; j >= 1; j--)
                {
                    fact *= j;
                }
                //Console.WriteLine(fact);
                sumFactDigits += fact;
                number = number / 10;
            }
            if (realNumber == sumFactDigits)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            //Console.WriteLine(sumFactDigits);
        }
    }
}
