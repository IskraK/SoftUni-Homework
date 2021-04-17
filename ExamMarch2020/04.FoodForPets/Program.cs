using System;

namespace _04.FoodForPets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double foodPets = double.Parse(Console.ReadLine());
            int totalDogFood = 0;
            int totalCatFood = 0;
            double biscuits = 0;
            for (int i = 1; i <= days; i++)
            {
                int dogFood = int.Parse(Console.ReadLine());
                int catFood = int.Parse(Console.ReadLine());
                totalDogFood += dogFood;
                totalCatFood += catFood;
                if (i % 3 == 0)
                {
                    biscuits = 0.1 * (dogFood + catFood);
                }
            }
            //•	"Total eaten biscuits: {количество изядени бисквитки}gr."
            //•	"{процент изядена храна}% of the food has been eaten."
            //•	"{процент изядена храна от кучето}% eaten from the dog."
            //•	"{процент изядена храна от котката}% eaten from the cat."
            //Количеството изядени бисквитки трябва да бъде закръглено до най – близкото цяло число, а процентът храна трябва да бъде форматиран до втората цифра след десетичния знак.
            double eatenFood = totalDogFood + totalCatFood;
            double pEatenFood = eatenFood / foodPets * 100;
            double pDogFood = 1.0*totalDogFood / eatenFood * 100;
            double pCatFood = 1.0*totalCatFood / eatenFood * 100;
            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{pEatenFood:f2}% of the food has been eaten.");
            Console.WriteLine($"{pDogFood:f2}% eaten from the dog.");
            Console.WriteLine($"{pCatFood:f2}% eaten from the cat.");
        }
    }
}
