using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> companies = new SortedDictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] parts = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string company = parts[0];
                string employeeID = parts[1];

                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new List<string>());
                }
                companies[company].Add(employeeID);

                input = Console.ReadLine();
            }

            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Key}");
                List<string> uniqueEmplyees = company
                    .Value
                    .Distinct()
                    .ToList();

                foreach (var employee in uniqueEmplyees)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
