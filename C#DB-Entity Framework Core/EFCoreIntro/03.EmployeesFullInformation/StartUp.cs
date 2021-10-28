using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _03.EmployeesFullInformation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            string result = GetEmployeesFullInformation(context);
            Console.WriteLine(result);
        }

        private static string GetEmployeesFullInformation(SoftUniContext softUniContext)
        {
            StringBuilder sb = new StringBuilder();

            var result = softUniContext.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}"))
                .ToArray();

            return sb.ToString().TrimEnd();
        }
    }
}
