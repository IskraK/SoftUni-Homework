using System;

namespace NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int biggest = int.MinValue;
            int smallest = int.MaxValue;
            for (int i = 0; i < count; i++)
            {
                int currNumber = int.Parse(Console.ReadLine());
                if (currNumber>biggest)
                {
                    biggest = currNumber;
                }
                if (currNumber<smallest)
                {
                    smallest = currNumber;
                }
            }
            Console.WriteLine($"Max number: {biggest}");
            Console.WriteLine($"Min number: {smallest}");
        }
    }
}
