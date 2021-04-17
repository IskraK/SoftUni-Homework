using System;

namespace SumPowerXN
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int y = x;
            for (int i = 1; i <= n; i++)
            {
                sum += y;
                y *= x;
            }
            Console.WriteLine(sum);
        }
    }
}
