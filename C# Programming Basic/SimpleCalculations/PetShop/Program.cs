using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDogs = int.Parse(Console.ReadLine());
            int numberOfOtherAnimals = int.Parse(Console.ReadLine());
            double dogFood = 2.50;
            double otherAnimalsFood = 4;
            double sum = numberOfDogs * dogFood + numberOfOtherAnimals * otherAnimalsFood;
            Console.WriteLine($"{sum} lv.");
        }
    }
}
