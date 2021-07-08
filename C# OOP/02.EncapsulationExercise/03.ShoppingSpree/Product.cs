using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Product
    {
        private string name;
        private int price;

        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value; 
            }
        }


        public int Price
        {
            get { return price; }
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
