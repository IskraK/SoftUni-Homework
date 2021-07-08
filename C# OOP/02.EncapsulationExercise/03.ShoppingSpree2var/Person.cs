using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree2var
{
    public class Person
    {
        private string name;
        private double money;
        private readonly List<Product> bag;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
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

        public double Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public void Buy(Product product)
        {
            if (product.Price > Money)
            {
                throw new InvalidOperationException($"{Name} can't afford {product.Name}");
            }

            Money -= product.Price;
            bag.Add(product);
            Console.WriteLine($"{Name} bought {product.Name}");

        }

        public override string ToString()
        {
            if (bag.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }

            return $"{Name} - {string.Join(", ", bag.Select(b => b.Name))}";
        }
    }
}
