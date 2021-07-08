using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const double baseCalories = 2.0;

        private readonly Dictionary<string, double> modifiersByToppingType = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 }
        };

        private string toppingType;
        private int weight;

        public Topping(string type,int weight)
        {
            ToppingType = type;
            Weight = weight;
        }

        public string ToppingType
        {
            get => toppingType;
            private set
            {
                if (!modifiersByToppingType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }

        public int Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range[1..50].");
                }
                weight = value;
            }
        }

        public double CalculateCalories() => baseCalories * modifiersByToppingType[ToppingType.ToLower()] * Weight;
    }
}
