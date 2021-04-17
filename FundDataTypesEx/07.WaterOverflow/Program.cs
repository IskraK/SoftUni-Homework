using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            byte capacity = 255;

            for (int i = 1; i <= n; i++)
            {
                int litresWater = int.Parse(Console.ReadLine());
                if (litresWater > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    capacity-=(byte)litresWater;
                }
            }
            int litresInTank = 255 - capacity;
            Console.WriteLine(litresInTank);
        }
    }
}
