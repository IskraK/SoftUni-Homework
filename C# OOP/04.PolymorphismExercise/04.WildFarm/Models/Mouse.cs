using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<string> EatenFoods => new List<string> { nameof(Vegetable), nameof(Fruit) };

        protected override double WeightIncrease => 0.10;

        public sealed override string ProduceSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
