using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private const double baseCaloriesPerGram = 2.00;
        private readonly Dictionary<string, double> flourTypesAndModifiers = new Dictionary<string, double>()
        {
            { "white", 1.5},
            { "wholegrain", 1.0},
        };
        private readonly Dictionary<string, double> bakingTechniquesAndModifiers = new Dictionary<string, double>()
        {
            { "crispy", 0.9},
            { "chewy", 1.1},
            { "homemade", 1.0},
        };
        
        private string flourType;
        private string bakingTechnique;
        private int weightGrams;

        public Dough(string flourType, string bakingTechnique, int weightGrams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            WeightGrams = weightGrams;
        }
        public string FlourType
        {
            get => flourType;
            private set
            {
                if (!flourTypesAndModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (!bakingTechniquesAndModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public int WeightGrams
        {
            get => weightGrams;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weightGrams = value;
            }
        }

        public double GetCalories()
        {
            return  baseCaloriesPerGram * WeightGrams * 
                    flourTypesAndModifiers[FlourType.ToLower()] * bakingTechniquesAndModifiers[BakingTechnique.ToLower()];
        }
    }
}
