using System;
using System.Linq;

namespace _04.AddVAT2var
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    decimal num = decimal.Parse(x);
                    return num * 1.2M;
                })
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:F2}"));
        }
    }
}
