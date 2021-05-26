using System;

namespace EvenPowersOf2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //double num = 1;
            //for (int i = 0; i <=n; i+=2)
            //{
            //    num = Math.Pow(2, i);
            //    Console.WriteLine(num);
            //}
            for (int i = 0; i <= n; i++)
            {
                if (i%2==0)
                {
                    double result = Math.Pow(2, i);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
