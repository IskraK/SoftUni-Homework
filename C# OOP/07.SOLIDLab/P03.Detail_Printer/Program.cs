using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Employee employee = new Employee("Pesho");
            employee.PrintEmployee(employee);

            List<string> docs = new List<string>() { "1", "2" };
            Manager manager = new Manager("Gosho",docs);
            manager.PrintEmployee(manager);
        }
    }
}
