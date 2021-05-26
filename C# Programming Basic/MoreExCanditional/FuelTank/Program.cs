using System;

namespace FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuel=Console.ReadLine().ToLower();
            double litresInTank = double.Parse(Console.ReadLine());
            //Ако литрите гориво са повече или равни на 25, на конзолата да се отпечата "You have enough {вида на горивото}.", ако са по - малко от 25, да се отпечата "Fill your tank with {вида на горивото}!".В случай, че бъде въведено гориво, различно от посоченото, да се отпечата "Invalid fuel!".
            if (fuel=="diesel"||fuel=="gasoline"||fuel=="gas")
            {
                if (litresInTank >= 25)
                {
                    if (fuel == "diesel")
                    {
                        Console.WriteLine($"You have enough {fuel}.");
                    }
                    else if (fuel == "gasoline")
                    {
                        Console.WriteLine($"You have enough {fuel}.");
                    }
                    else if (fuel == "gas")
                    {
                        Console.WriteLine($"You have enough {fuel}.");
                    }
                }
                else
                {
                    if (fuel == "diesel")
                    {
                        Console.WriteLine($"Fill your tank with {fuel}!");
                    }
                    else if (fuel == "gasoline")
                    {
                        Console.WriteLine($"Fill your tank with {fuel}!");
                    }
                    else if (fuel == "gas")
                    {
                        Console.WriteLine($"Fill your tank with {fuel}!");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Invalid fuel!");
            }
        }
    }
}
