using System;

namespace _03.RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] fibonacci = new int[n];
            while (n >= 2)
            {
                fibonacci[0] = 1;
                fibonacci[1] = 1;
                for (int i = 2; i < n; i++)
                {
                    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                }
                break;
            }
            if (n < 2)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine($"{ fibonacci[n - 1]}");
            }
        }
    }
}
