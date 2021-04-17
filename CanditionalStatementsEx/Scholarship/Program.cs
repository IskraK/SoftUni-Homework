using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Доход в лева -реално число в интервала[0.00..6000.00]
            //2.Среден успех - реално число в интервала[2.00...6.00]
            //3.Минимална работна заплата -реално число в интервала[0.00..1000.00]
            double income = double.Parse(Console.ReadLine());
            double averageMark = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());
            double scholarshipForExcellent = averageMark * 25;
            double socialScholarship = minimalSalary * 0.35;
            if (income > minimalSalary||averageMark <4.50)
            {
                Console.WriteLine($"You cannot get a scholarship!");
            }
            else if (income > minimalSalary && averageMark > 4.50 && averageMark < 5.50)
            {
                Console.WriteLine($"You cannot get a scholarship!");
            }
            else if (income < minimalSalary&& averageMark >= 4.50 && averageMark < 5.50)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else if (income > minimalSalary&& averageMark >= 5.50)
            {
                Console.WriteLine($"You get a scholarship for excellent results {scholarshipForExcellent} BGN");
            }
            else if (income < minimalSalary&& averageMark >=5.50 && socialScholarship < scholarshipForExcellent)
            {
                Console.WriteLine($"You get a scholarship for excellent results {scholarshipForExcellent} BGN");
            }
            else if (income < minimalSalary && averageMark >= 5.50 && socialScholarship > scholarshipForExcellent)   
            { 
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
        }
    }
} 
