using System;

namespace _02.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double distance1 = GetDistanceToCentre(x1, y1);
            double distance2 = GetDistanceToCentre(x2, y2);

            if (distance1 <= distance2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }

        private static double GetDistanceToCentre(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x,2)+Math.Pow(y,2));
        }
    }
}
