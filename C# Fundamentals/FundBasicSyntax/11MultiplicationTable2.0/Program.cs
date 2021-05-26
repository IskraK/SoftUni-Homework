using System;

namespace _11MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());
            if (num > 10)
            {
                Console.WriteLine($"{n} X {num} = {n*num}");
            }
            else
            {
                for (int i = num; i <= 10 ; i++)
                {
                    Console.WriteLine($"{n} X {i} = {n * i}");
                }
            }
        }
    }
}
