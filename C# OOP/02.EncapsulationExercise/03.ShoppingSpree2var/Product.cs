using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree2var
{
    public class Product
    {
        private string name;
        private double price;

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public double Price
        {
            get => price;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                price = value;
            }
        }

    }
}
