using System;

namespace FoodPeds
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double foodPets = double.Parse(Console.ReadLine());
            double biscuites = 0;
            double totalDogFood = 0;
            double totalCatFood = 0;
            for (int i = 1; i <= days; i++)
            {
                int dogFood = int.Parse(Console.ReadLine());
                int catFood = int.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    biscuites += (catFood + dogFood) * 0.1;
                }
                totalDogFood += dogFood;
                totalCatFood += catFood;
            }
            double eatenFood = totalDogFood + totalCatFood;
            double pEatenFood = eatenFood / foodPets * 100;
            double pDogFood = totalDogFood / eatenFood * 100;
            double pCatFood = totalCatFood / eatenFood * 100;
            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuites)}gr.");
            Console.WriteLine($"{pEatenFood:f2}% of the food has been eaten.");
            Console.WriteLine($"{pDogFood:f2}% eaten from the dog.");
            Console.WriteLine($"{pCatFood:f2}% eaten from the cat.");
        }
    }
}
