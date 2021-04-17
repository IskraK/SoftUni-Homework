using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int cakePieces = a * b;
            string input = Console.ReadLine();
            while (cakePieces >= 0)
            {
                if (input == "STOP")
                {
                    break;
                }
                int cake = int.Parse(input);
                cakePieces -= cake;
                input = Console.ReadLine();

            }
            if (cakePieces >= 0)
            {
                Console.WriteLine($"{cakePieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakePieces)} pieces more.");
            }
        }
    }
}
