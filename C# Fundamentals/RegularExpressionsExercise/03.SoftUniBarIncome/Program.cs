using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            //% George %< Croissant >| 2 | 10.3$

            string input = Console.ReadLine();
            string pattern = @"(?:%(?<name>[A-Z][a-z]+)%)(?:[^%$|.]+)?(?:<(?<product>\w+)>)(?:[^%$|.]+)?(?:\|(?<count>\d+)\|)(?:[^%$|.0-9]+)?(?<price>\d+\.?\d+?)\$";
            Regex regex = new Regex(pattern);
            double income = 0;

            while (input != "end of shift")
            {
                if (regex.IsMatch(input))
                {
                    string name = regex.Match(input).Groups["name"].Value;
                    string product = regex.Match(input).Groups["product"].Value;
                    int count = int.Parse(regex.Match(input).Groups["count"].Value);
                    double price = double.Parse(regex.Match(input).Groups["price"].Value);
                    double totalPrice = price * count;
                    Console.WriteLine($"{name}: {product} - {totalPrice:F2}");
                    income += totalPrice;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {income:F2}");
        }
    }
}
