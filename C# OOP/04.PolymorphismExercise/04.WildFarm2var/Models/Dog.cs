using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight,  string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<string> EatenFoods => new List<string> { nameof(Meat) };

        protected override double WeightIncrease => 0.4;

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
