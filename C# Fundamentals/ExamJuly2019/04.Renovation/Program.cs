using System;

namespace _04.Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            int hight = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int area = 4 * hight * width ;
            double areaPaint = Math.Ceiling(area-area*1.0*p/100);
            string input = Console.ReadLine();
            while (input != "Tired!")
            {
                int paintLitres = int.Parse(input);
                areaPaint -= paintLitres;
                if (areaPaint <= 0)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if (areaPaint == 0)
            {
                Console.WriteLine($"All walls are painted! Great job, Pesho!");
            }
            else if (areaPaint > 0)
            {
                Console.WriteLine($"{areaPaint} quadratic m left.");
            }
            else
            {
                Console.WriteLine($"All walls are painted and you have {Math.Abs(areaPaint)} l paint left!");
            }
        }
    }
}
