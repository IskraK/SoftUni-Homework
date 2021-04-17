using System;

namespace Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int countBottles = int.Parse(Console.ReadLine());
            int oneBottle = 750;
            int detergent = countBottles * oneBottle;
            int usedDetergent = 0;
            int numberDishes = 0;
            int numberPots = 0;
            int counter = 0;
            string input = Console.ReadLine();
            while (detergent >= 0)
            {
                counter++;
                if (input == "End")
                {
                    break;
                }
                if (counter % 3 == 0)
                {
                    int pots = int.Parse(input);
                    usedDetergent = pots * 15;
                    numberPots += pots;
                }
                else
                {
                    int dishes = int.Parse(input);
                    usedDetergent = dishes * 5;
                    numberDishes += dishes;
                }
                detergent -= usedDetergent;
                input = Console.ReadLine();
            }
            if (detergent >= 0)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{numberDishes} dishes and {numberPots} pots were washed.");
                Console.WriteLine($"Leftover detergent {detergent} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(detergent)} ml. more necessary!");
            }
        }
    }
}
