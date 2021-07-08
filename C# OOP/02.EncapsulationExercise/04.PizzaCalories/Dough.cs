using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const double baseCalories = 2.0;

        private readonly Dictionary<string, double> modifiersByType = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 }
        };

        private readonly Dictionary<string, double> modifiersByBaking = new Dictionary<string, double>()
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType,string baking,int weight)
        {
            FlourType = flourType;
            BakingTechnique = baking;
            Weight = weight;
        }
        public string FlourType
        {
            get => flourType; 
            private set 
            {
                if (!modifiersByType.ContainsKey(value.ToLower()))
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
                if (!modifiersByBaking.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value; 
            }
        }

        public int Weight 
        {
            get => weight; 
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double CalculateCalories() => baseCalories * modifiersByType[FlourType.ToLower()] * modifiersByBaking[BakingTechnique.ToLower()] * Weight;
    }
}
