using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private readonly List<Employee> employees;
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            employees = new List<Employee>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return employees.Count;
            }
        }

        public void Add(Employee employee)
        {
            if (Capacity > Count)
            {
                employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            if (employees.Any(n => n.Name == name))
            {
                Employee employeeToRemove = employees.FirstOrDefault(n => n.Name == name);
                employees.Remove(employeeToRemove);
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            return employees.OrderByDescending(e => e.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return employees.FirstOrDefault(n => n.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
