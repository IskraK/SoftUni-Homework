using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<string> EatenFoods => new List<string> { nameof(Vegetable), nameof(Meat), nameof(Fruit), nameof(Seeds)};

        protected override double WeightIncrease => 0.35;

        public sealed override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
