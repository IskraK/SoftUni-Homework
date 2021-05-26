using System;

namespace AverageNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
            }
            double avgSum = 1.0 * sum / n;
            Console.WriteLine($"{avgSum:f2}");
        }
    }
}
