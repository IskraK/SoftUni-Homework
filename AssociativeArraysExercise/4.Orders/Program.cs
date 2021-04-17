using System;
using System.Collections.Generic;

namespace _4.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] currInput = input.Split();
                string name = currInput[0];
                double price = double.Parse(currInput[1]);
                int quantity = int.Parse(currInput[2]);

                Product product = new Product(price, quantity);

                if (products.ContainsKey(name))
                {
                    products[name].Price = price;
                    products[name].Quantity += quantity;
                }
                else
                {
                    products.Add(name, product);
                }

                input = Console.ReadLine();
            }

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.TotalPrice():F2}");
            }
        }
    }

    public class Product
    {

        public double Price { get; set; }
        public int Quantity { get; set; }
        public Product(double price,int quantity)
        {
            Price = price;
            Quantity = quantity;
        }

        public double TotalPrice()
        {
            return Price * Quantity;
        }
    }
}
