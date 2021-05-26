using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double totalPrice = 0;
            List<string> furniture = new List<string>();

            while (input != "Purchase")
            {
                //">>{furniture name}<<{price}!{quantity}"
                string pattern = @">>(?<name>(?:[A-Z]+)|(?:[A-Z][a-z]+))<<(?<price>(?:[0-9]+?.?[0-9]+)|(?:[0-9]+))!(?<quantity>[0-9]+)";
                //@"\B>>(?<furnitureName>[A-Za-z]+)<<(?<price>(?:\d+)|(?:\d+\.\d+))\!(?<quantity>\d+)\b" working var2
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(input))
                {
                    var validFurniture = regex.Matches(input);

                    foreach (Match item in validFurniture)
                    {
                        string furnitureName = item.Groups["name"].Value;
                        double price = double.Parse(item.Groups["price"].Value);
                        int quantity = int.Parse(item.Groups["quantity"].Value);
                        totalPrice += price * quantity;
                        furniture.Add(furnitureName);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            if (furniture.Count != 0)
            {
            Console.WriteLine(string.Join("\n", furniture));
            }

            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
