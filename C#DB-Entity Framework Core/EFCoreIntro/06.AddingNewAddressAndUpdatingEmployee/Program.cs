using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace _06.AddingNewAddressAndUpdatingEmployee
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            string result = AddNewAddressToEmployee(context);
            Console.WriteLine(result);
        }

        private static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            Employee employeeNakov = context.Employees
                .Where(e => e.LastName == "Nakov")
                .FirstOrDefault();

            employeeNakov.Address=newAddress;
            context.SaveChanges();

            string[] employeesAddresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToArray();

            return string.Join(Environment.NewLine, employeesAddresses);
        }
    }
}
