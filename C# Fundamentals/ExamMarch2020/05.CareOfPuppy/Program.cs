using System;

namespace _05.CareOfPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int boughtFood = int.Parse(Console.ReadLine());
            boughtFood *= 1000;
            string input = Console.ReadLine();
            int allEatenFood = 0;
            while (input != "Adopted")
            {
                int eatenFood = int.Parse(input);
                allEatenFood += eatenFood;
                input = Console.ReadLine();
            }
            if (allEatenFood <= boughtFood)
            {
                Console.WriteLine($"Food is enough! Leftovers: {boughtFood-allEatenFood} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {allEatenFood-boughtFood} grams more.");
            }
        }
    }
}
