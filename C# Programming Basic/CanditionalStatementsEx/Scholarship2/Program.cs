using System;

namespace Scholarship2
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());
            double socialScholarship = Math.Floor(minSalary * 0.35);
            double scoresScholarship = Math.Floor(averageGrade * 25);
            if (income < minSalary && averageGrade >= 5.5)
            {
                if (socialScholarship > scoresScholarship)
                {
                    Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
                }
                else
                {
                    Console.WriteLine($"You get scholarship for excellent results {scoresScholarship} BGN");
                }
            }
            else if (income > minSalary && averageGrade >= 5.5)
            {
                Console.WriteLine($"You get scholarship for excellent results {scoresScholarship} BGN");
            }
            else if (income < minSalary && averageGrade > 4.5 && averageGrade < 5.5)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}

   
