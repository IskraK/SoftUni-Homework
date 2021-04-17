using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());
            double singlePrice = 7.61;
            double totalPrice = area * singlePrice * 0.82;
            double discount = area * singlePrice * 0.18;
            Console.WriteLine($"The final price is : {totalPrice} lv.");
            Console.WriteLine($"The discount is : {discount} lv.");

        }
    }
}
