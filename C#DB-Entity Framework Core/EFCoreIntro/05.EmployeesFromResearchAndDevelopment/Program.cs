using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _05.EmployeesFromResearchAndDevelopment
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            string result = GetEmployeesFromResearchAndDevelopment(context);
            Console.WriteLine(result);
        }

        private static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new 
                { 
                    e.FirstName, 
                    e.LastName, 
                    DepartmentName = e.Department.Name, 
                    e.Salary 
                })
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
