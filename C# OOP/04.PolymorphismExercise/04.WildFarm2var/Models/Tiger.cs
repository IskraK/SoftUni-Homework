using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<string> EatenFoods => new List<string> { nameof(Meat) };

        protected override double WeightIncrease => 1.0;

        public sealed override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
