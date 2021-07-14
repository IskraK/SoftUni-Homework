using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<string> EatenFoods => new List<string> { nameof(Meat) };

        protected override double WeightIncrease => 0.25;

        public sealed override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
