using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> productsList = new List<Product>();

            try
            {
                string[] personInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < personInput.Length; i++)
                {
                    string[] personInfo = personInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = personInfo[0];
                    int money = int.Parse(personInfo[1]);
                    Person person = new Person(name, money);
                    people.Add(person);
                }

                string[] productInput = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productInput.Length; i++)
                {
                    string[] productInfo = productInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string productName = productInfo[0];
                    int productPrice = int.Parse(productInfo[1]);
                    Product product = new Product(productName, productPrice);
                    productsList.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    string[] cmd = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = cmd[0];
                    string productName = cmd[1];

                    Person person = people.FirstOrDefault(n => n.Name == name);
                    Product product = productsList.FirstOrDefault(n => n.Name == productName);

                    if (person.Money >= product.Price)
                    {
                        person.AddProduct(product);
                        person.Money -= product.Price;
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                input = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.Write($"{person.Name} - ");
                    Console.WriteLine(string.Join(", ",person.Products.Select(n => n.Name)));
                }
            }
        }
    }
}
