using System;

namespace Scholarship3
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageSuccess = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            // социална стипендия - доход на член от семейството по-малък от минималната работна заплата и успех над 4.5
            // Размер на социалната стипендия - 35% от минималната работна заплата

            // отличен успех - успех над 5.5, включително
            // успехът на ученика, умножен по коефициент 25.

            double scholarship = Math.Floor(averageSuccess * 25);
            double socialScholarship = Math.Floor(minSalary * 0.35);

            if (averageSuccess >= 5.50)
            {
                if (scholarship >= socialScholarship || income > minSalary)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {scholarship} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
                }
            }
            else if (income < minSalary && averageSuccess > 4.50)
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
