using System;

namespace _1.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            double totalPriceWithoutTaxes = 0;
            double totalPriceWithTaxes = 0;
            double taxes = 0;

            while (true)
            {
                input = Console.ReadLine();

                if (input == "special" || input == "regular")
                {
                    break;
                }

                double price = double.Parse(input);

                if (price <= 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                totalPriceWithoutTaxes += price;
                }
            }

            taxes = 0.2 * totalPriceWithoutTaxes;
            totalPriceWithTaxes = totalPriceWithoutTaxes + taxes;

            if (input == "special")
            {
                totalPriceWithTaxes *= 0.9;
            }

            if (totalPriceWithTaxes == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPriceWithoutTaxes:F2}$");
                Console.WriteLine($"Taxes: {taxes:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPriceWithTaxes:F2}$");
            }
        }
    }
}
