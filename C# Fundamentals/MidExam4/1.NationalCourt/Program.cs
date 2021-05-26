using System;

namespace _1.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int efficiency1 = int.Parse(Console.ReadLine());
            int efficiency2 = int.Parse(Console.ReadLine());
            int efficiency3 = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());

            int totalEfficiency = efficiency1 + efficiency2 + efficiency3;
            int hours = (int)Math.Ceiling(1.0*peopleCount / totalEfficiency);

            if (hours > 3)
            {
                hours += hours/3;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
