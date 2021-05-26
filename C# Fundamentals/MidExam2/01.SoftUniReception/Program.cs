using System;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int efficiency1 = int.Parse(Console.ReadLine());
            int efficiency2 = int.Parse(Console.ReadLine());
            int efficiency3 = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            int hours = 0;
            int totalEfficiency = efficiency1 + efficiency2 + efficiency3;

            while (studentsCount > 0)
            {
                hours++;
                if (hours % 4 == 0)
                {
                    continue;
                }
                    studentsCount -= totalEfficiency;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
