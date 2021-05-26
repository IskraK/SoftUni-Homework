using System;

namespace _10.LowerORUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch = char.Parse(Console.ReadLine());
            int numChar = (int)ch;

            if (numChar >= 65 && numChar <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else if (numChar >= 97 && numChar <=122)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
