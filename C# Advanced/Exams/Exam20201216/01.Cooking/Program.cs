using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputLiquides = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] inputIngredients = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(inputLiquides);
            Stack<int> ingredients = new Stack<int>(inputIngredients);
            Dictionary<string, int> food = new Dictionary<string, int>();
            food.Add("Bread", 0);
            food.Add("Cake", 0);
            food.Add("Fruit Pie", 0);
            food.Add("Pastry", 0);

            while (true)
            {
                if (liquids.Count == 0 || ingredients.Count == 0)
                {
                    break;
                }
                int sumOfLiquidAndIngredient = liquids.Peek() + ingredients.Peek();

                if (sumOfLiquidAndIngredient == 25)
                {
                    food["Bread"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sumOfLiquidAndIngredient == 50)
                {
                    food["Cake"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sumOfLiquidAndIngredient == 75)
                {
                    food["Pastry"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sumOfLiquidAndIngredient == 100)
                {
                    food["Fruit Pie"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }

            if (food.All(n => n.Value >= 1))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            foreach (var item in food)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
