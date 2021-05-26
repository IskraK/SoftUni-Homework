using System;
using System.Linq;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string reversed = string.Concat(input.Reverse());

            Console.WriteLine(reversed);
        }
    }
}
