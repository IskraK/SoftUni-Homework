using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree2var
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();


            try
            {
                string[] peopleInput = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < peopleInput.Length; i += 2)
                {
                    string name = peopleInput[i];
                    double money = double.Parse(peopleInput[i + 1]);
                    Person person = new Person(name, money);
                    people.Add(person);
                }

                string[] productInput = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < productInput.Length; i += 2)
                {
                    string name = productInput[i];
                    double price = double.Parse(productInput[i + 1]);
                    Product product = new Product(name, price);
                    products.Add(product);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            string[] command = Console.ReadLine().Split();
            while (command[0] != "END")
            {
                try
                {
                    string personName = command[0];
                    string productName = command[1];
                    Product product = products.FirstOrDefault(p => p.Name == productName);
                    people.FirstOrDefault(p => p.Name == personName).Buy(product);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }
}
