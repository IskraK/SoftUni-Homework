using System;

namespace _05.DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            long days = Math.Abs(DateModifier.DifferenceBetweenDates(firstDate, secondDate));

            Console.WriteLine(days);
        }
    }
}
