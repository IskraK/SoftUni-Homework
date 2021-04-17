using System;

namespace MomchilAlg3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int oddSum = 0;
            for (int i = 1; i <= n; i+=2)
            {
                oddSum += i;
            }
            Console.WriteLine(oddSum);
        }
    }
}
