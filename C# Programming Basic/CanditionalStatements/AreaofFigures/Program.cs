using System;

namespace AreaofFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0;
            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                area = side * side;
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                area = Math.PI * radius * radius;
            }
            else
            {
                double side1 = double.Parse(Console.ReadLine());
                double hight1 = double.Parse(Console.ReadLine());
                area = side1 * hight1 * 0.5;
            }
            Console.WriteLine($"{Math.Round(area,3)}");
        }
    }
}
