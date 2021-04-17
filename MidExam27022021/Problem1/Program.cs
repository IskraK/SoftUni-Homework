using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int countBattles = int.Parse(Console.ReadLine());
            double totalExperience = 0;
            for (int i = 1; i <= countBattles; i++)
            {
                double earnedExperience = double.Parse(Console.ReadLine());
                totalExperience += earnedExperience;

                if (i % 3 == 0)
                {
                    totalExperience += 0.15 * earnedExperience;
                }

                if (i % 5 == 0)
                {
                    totalExperience -= 0.1 * earnedExperience;
                }

                if (i % 15 == 0)
                {
                    totalExperience += 0.05 * earnedExperience;
                }

                if (totalExperience >= neededExperience)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {i} battles.");
                    break;
                }
            }

            if (totalExperience < neededExperience)
            {
            Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience-totalExperience:F2} more needed.");
            }
        }
    }
}
