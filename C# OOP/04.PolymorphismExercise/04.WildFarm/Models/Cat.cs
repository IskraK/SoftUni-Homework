using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<string> EatenFoods => new List<string> {nameof(Vegetable), nameof(Meat) };

        protected override double WeightIncrease => 0.3;

        public sealed override string ProduceSound()
        {
            return "Meow";
        }
    }
}
