using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _04.EmployeesWithSalaryOver50000
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            string result = GetEmployeesWithSalaryOver50000(context);
            Console.WriteLine(result);
        }

        private static string GetEmployeesWithSalaryOver50000(SoftUniContext softUniContext)
        {
            StringBuilder sb = new StringBuilder();
            var employees = softUniContext.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new { e.FirstName, e.Salary })
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
