using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DippingSauce = 150;
            const int GreenSalad = 250;
            const int ChocolateCake = 300;
            const int Lobster = 400;

            int[] ingredientsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] freshnessInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> ingredients = new Queue<int>(ingredientsInput);
            Stack<int> freashness = new Stack<int>(freshnessInput);

            SortedDictionary<string, int> dishes = new SortedDictionary<string, int>();
            dishes.Add("Dipping sauce", 0);
            dishes.Add("Green salad", 0);
            dishes.Add("Chocolate cake", 0);
            dishes.Add("Lobster", 0);

            while (ingredients.Count > 0 && freashness.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                if (ingredients.Peek() * freashness.Peek() == DippingSauce)
                {
                    dishes["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freashness.Pop();
                }
                else if (ingredients.Peek() * freashness.Peek() == GreenSalad)
                {
                    dishes["Green salad"]++;
                    ingredients.Dequeue();
                    freashness.Pop();
                }
                else if (ingredients.Peek() * freashness.Peek() == ChocolateCake)
                {
                    dishes["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freashness.Pop();
                }
                else if (ingredients.Peek() * freashness.Peek() == Lobster)
                {
                    dishes["Lobster"]++;
                    ingredients.Dequeue();
                    freashness.Pop();
                }
                else
                {
                    freashness.Pop();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }

            if (dishes["Dipping sauce"] >=1 && dishes["Green salad"] >= 1 && dishes["Chocolate cake"] >= 1 && dishes["Lobster"] >= 1 )
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            var sortedDishes = dishes.Where(n => n.Value >= 1).ToDictionary(x => x.Key, y => y.Value);
            foreach (var dish in sortedDishes)
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
