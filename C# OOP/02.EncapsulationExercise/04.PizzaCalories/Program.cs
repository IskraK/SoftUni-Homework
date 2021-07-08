using System;

namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split()[1];

                string[] doughInput = Console.ReadLine().Split();

                string doughType = doughInput[1];
                string bakingTechnique = doughInput[2];
                int doughWeight = int.Parse(doughInput[3]);

                Dough dough = new Dough(doughType, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string[] toppingInput = Console.ReadLine().Split();

                while (toppingInput[0] != "END")
                {
                    string toppingType = toppingInput[1];
                    int toppingWeight = int.Parse(toppingInput[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    toppingInput = Console.ReadLine().Split();
                }

                Console.WriteLine($"{pizzaName} - {pizza.CalculateTotalCalories():F2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // 92/100
        }
    }
}
