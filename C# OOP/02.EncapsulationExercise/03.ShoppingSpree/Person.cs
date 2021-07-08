using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private readonly List<Product> products;

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            products = new List<Product>();
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


        public int Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                return this.products;
            }
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
