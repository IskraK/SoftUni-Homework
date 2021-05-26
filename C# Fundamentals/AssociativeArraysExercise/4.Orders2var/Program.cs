using System;
using System.Collections.Generic;

namespace _4.Orders2var
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> priceByProduct = new Dictionary<string, decimal>();
            Dictionary<string, int> quantityByProduct = new Dictionary<string, int>();

            string line = Console.ReadLine();

            while (line != "buy")
            {
                string[] parts = line.Split();
                string product = parts[0];
                decimal price = decimal.Parse(parts[1]);
                int quantity = int.Parse(parts[2]);

                if (priceByProduct.ContainsKey(product))
                {
                    quantityByProduct[product] += quantity;
                    priceByProduct[product] = price;
                }
                else
                {
                    priceByProduct.Add(product, price);
                    quantityByProduct.Add(product, quantity);
                }

                line = Console.ReadLine();
            }

            foreach (var kvp in priceByProduct)
            {
                string product = kvp.Key;
                decimal price = kvp.Value;
                int quantity = quantityByProduct[product];
                decimal totalPrice = price * quantity;

                Console.WriteLine($"{product} -> {totalPrice:F2}");
            }

        }
    }
}
