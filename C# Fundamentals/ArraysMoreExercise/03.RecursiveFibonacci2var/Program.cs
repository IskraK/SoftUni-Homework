using System;

namespace _03.RecursiveFibonacci2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(n));
        }

        private static int GetFibonacci(int n)
        {
            int result = 1;
            if (n > 2)
            {
                result = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            }
            return result;
        }
    }
}
