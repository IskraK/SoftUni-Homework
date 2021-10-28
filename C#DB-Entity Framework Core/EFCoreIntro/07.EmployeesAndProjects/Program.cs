using SoftUni.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _07.EmployeesAndProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            string result = GetEmployeesInPeriod(context);
            Console.WriteLine(result);
        }

        private static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.EmployeesProjects.All(e => e.Project.StartDate.Year >= 2001 && e.Project.StartDate.Year <= 2003))
                .Select(e => new 
                { 
                    e.FirstName, 
                    e.LastName, 
                    managerFullName = string.Concat(e.Manager.FirstName, " ", e.Manager.LastName),
                    employeeProjects = e.EmployeesProjects.Select(p => new { p.Project.Name,p.Project.StartDate,p.Project.EndDate })
                })
                .Take(10)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.managerFullName}");

                foreach (var project in employee.employeeProjects)
                {
                    string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    string endDate = project.EndDate == null
                        ? "not finished"
                        : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
