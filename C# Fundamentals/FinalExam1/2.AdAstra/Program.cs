using System;
using System.Text.RegularExpressions;

namespace _2.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            const int caloriesPerDay = 2000;
            string input = Console.ReadLine();
            string pattern = @"([#|])(?<name>[A-Za-z ]+)(\1)(?<date>[0-9]{2}/[0-9]{2}/[0-9]{2})(\1)(?<calories>\d+)(\1)";
            Regex regex = new Regex(pattern);
            var foods = regex.Matches(input);
            int totalCalories = 0;

            foreach (Match food in foods)
            {
                int calories = int.Parse(food.Groups["calories"].Value);
                totalCalories += calories;
            }

            int days = totalCalories / caloriesPerDay;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match food in foods)
            {
                Console.WriteLine($"Item: {food.Groups["name"].Value}, Best before: {food.Groups["date"].Value}, Nutrition: {food.Groups["calories"].Value}");
            }
        }
    }
}
