using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        //•	Name: string
        //•	Capacity: int - the maximum allowed number of ingredients in the cocktail
        //•	MaxAlcoholLevel: int - the maximum allowed amount of alcohol in the cocktail

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int CurrentAlcoholLevel 
        {
            get 
            {
                int currAlcoholLevel = 0;
                foreach (var ingredient in Ingredients)
                {
                    currAlcoholLevel += ingredient.Alcohol;
                }
                return currAlcoholLevel;
            }
        }

        public void Add(Ingredient ingredient)
        {

            if (!Ingredients.Any(n => n.Name == ingredient.Name          
                && ingredient.Quantity <= Capacity
                && ingredient.Alcohol <= MaxAlcoholLevel))
            {
                Ingredients.Add(ingredient);
                Capacity -= ingredient.Quantity;
                MaxAlcoholLevel -= ingredient.Alcohol;
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.Any(n => n.Name == name))
            {
                Ingredient ingredientToRemove = Ingredients.FirstOrDefault(n => n.Name == name);
                Capacity += ingredientToRemove.Quantity;
                MaxAlcoholLevel += ingredientToRemove.Alcohol;
                Ingredients.Remove(ingredientToRemove);
                return true;
            }
                return false;
        }

        public Ingredient FindIngredient(string name)
        {
            if (Ingredients.Any(n => n.Name == name))
            {
                return Ingredients.FirstOrDefault(n => n.Name == name);
            }
                return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(n => n.Alcohol).FirstOrDefault();
        }

        public string Report() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
