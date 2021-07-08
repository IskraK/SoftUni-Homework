using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private const double baseCaloriesPerGram = 2.00;
        private readonly Dictionary<string, double> toppingTypesAndModifiers = new Dictionary<string, double>()
        {
            { "meat", 1.2},
            { "veggies", 0.8},
            { "cheese", 1.1},
            { "sauce", 0.9},
        };
        private string type;
        private int weightGrams;

        public Topping(string type, int weightGrams)
        {
            Type = type;
            WeightGrams = weightGrams;
        }

        public string Type
        {
            get => type;
            private set
            {
                if (!toppingTypesAndModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        public int WeightGrams
        {
            get => weightGrams;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weightGrams = value;
            }
        }

        public double GetCalories()
        {
            return baseCaloriesPerGram * WeightGrams * toppingTypesAndModifiers[Type.ToLower()];
        }
    }
}
