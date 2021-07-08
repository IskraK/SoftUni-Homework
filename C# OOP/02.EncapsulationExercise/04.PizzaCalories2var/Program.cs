using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughtProperties = Console.ReadLine().Split();
            try
            {
                Dough dough = new Dough(doughtProperties[1], doughtProperties[2], int.Parse(doughtProperties[3]));
                Pizza pizza = new Pizza(pizzaName, dough);

                string[] toppingProperties = Console.ReadLine().Split();
                while (toppingProperties[0] != "END")
                {
                    pizza.AddTopping(new Topping(toppingProperties[1], int.Parse(toppingProperties[2])));

                    toppingProperties = Console.ReadLine().Split();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():F2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // 100/100
        }
    }
}
