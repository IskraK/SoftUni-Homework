using System;

namespace BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int plunderPerDay = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                totalPlunder += plunderPerDay;

                if (i % 3 == 0)
                {
                    totalPlunder += 0.5 * plunderPerDay;
                }

                if (i % 5 == 0)
                {
                    totalPlunder -= 0.3 * totalPlunder;
                }
            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:F2} plunder gained.");
            }
            else
            {
                double percentage = totalPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {percentage:F2}% of the plunder.");
            }
        }
    }
}
