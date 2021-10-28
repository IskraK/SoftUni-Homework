using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            string result = RemoveTown(context);
            Console.WriteLine(result);
        }


        //3.Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext softUniContext)
        {
            StringBuilder sb = new StringBuilder();

            var result = softUniContext.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}"))
                .ToArray();

            return sb.ToString().TrimEnd();
        }


        //4.Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext softUniContext)
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


        //5.Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
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


        //6.Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            Employee employeeNakov = context.Employees
                .Where(e => e.LastName == "Nakov")
                .First();

            employeeNakov.Address = newAddress;
            context.SaveChanges();

            string[] employeesAddresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToArray();

            return string.Join(Environment.NewLine, employeesAddresses);
        }


        //7.Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.EmployeesProjects.All(e => e.Project.StartDate.Year >= 2001 && e.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    managerFullName = string.Concat(e.Manager.FirstName, " ", e.Manager.LastName),
                    employeeProjects = e.EmployeesProjects.Select(p => new { p.Project.Name, p.Project.StartDate, p.Project.EndDate })
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


        //8.Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    a.AddressText,
                    townName = a.Town.Name,
                    employeeCount = a.Employees.Count
                })
                .Take(10)
                .ToArray();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.townName} - {address.employeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }


        //9.Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    employeeProjects = e.EmployeesProjects.Select(p => p.Project.Name)
                }
                )
                .First();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.employeeProjects.OrderBy(p => p))
            {
                sb.AppendLine(project);
            }

            return sb.ToString().TrimEnd();
        }


        //10.Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    d.Name,
                    d.Manager.FirstName,
                    d.Manager.LastName,
                    d.Employees
                })
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} – {department.FirstName} {department.LastName}");

                foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }



        //11.Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new { p.Name, p.Description, p.StartDate })
                .ToArray();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }



        //12.Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                e.Department.Name == "Tool Design" ||
                e.Department.Name == "Marketing" ||
                e.Department.Name == "Information Services");

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employeesToDisplay = employees
                .Select(e => new { e.FirstName, e.LastName, e.Salary })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesToDisplay)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }



        //13.Find Employees by First Name Starting with "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.Substring(0, 2) == "Sa")
                .Select(e => new { e.FirstName, e.LastName, e.JobTitle, e.Salary })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }



        //14.Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeesWithProjectId2 = context.EmployeesProjects
                .Where(e => e.ProjectId == 2)
                .ToArray();

            context.EmployeesProjects.RemoveRange(employeesWithProjectId2);

            var projectsToRemove = context.Projects.Find(2);
            context.Projects.Remove(projectsToRemove);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            return string.Join(Environment.NewLine, projects);
        }


        //15.Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            Address[] addressesInSeattle = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToArray();

            Employee[] employeesInSeattle = context.Employees.ToArray()
                .Where(e => addressesInSeattle.Any(a => a.AddressId == e.AddressId))
                .ToArray();

            foreach (var employee in employeesInSeattle)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesInSeattle);

            Town townSeattle = context.Towns.First(t => t.Name == "Seattle");
            context.Towns.Remove(townSeattle);

            context.SaveChanges();

            return $"{addressesInSeattle.Length} addresses in Seattle were deleted";
        }
    }
}
