using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private  Dough dough;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }


        public double CalculateTotalCalories() => dough.CalculateCalories() + toppings.Sum(t => t.CalculateCalories());


        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        //private double CalculateTotalCalories()
        //{
        //    return dough.Calories + toppings.Sum(t => t.Calories);
        //}
    }
}
