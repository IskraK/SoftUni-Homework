using System;

namespace Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            int number = 1;
            while (number <= target)
            {
                Console.WriteLine(number);
                number = 2 * number + 1;
            }
        }
    }
}
