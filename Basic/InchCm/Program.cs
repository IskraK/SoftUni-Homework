using System;

namespace InchCm
{
    class Program
    {
        static void Main(string[] args)
        {
            double numInch = double.Parse(Console.ReadLine());
            double numCm = numInch * 2.54;
            Console.WriteLine(numCm);
        }
    }
}
