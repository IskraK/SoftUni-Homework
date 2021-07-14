using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.WildFarm
{
    public abstract class Animal
    {
        public Animal(string name,double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected abstract IReadOnlyCollection<string> EatenFoods { get; }
        protected abstract double WeightIncrease { get; }
        public abstract string ProduceSound();
        public void Eat(Food food)
        {
            if (!EatenFoods.Contains(food.GetType().Name) && EatenFoods.Count != 0)
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity * WeightIncrease;
        }
    }
}
