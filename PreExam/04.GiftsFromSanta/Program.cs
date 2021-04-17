using System;

namespace _04.GiftsFromSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            int adresNum = int.Parse(Console.ReadLine());
            
            for (int i = endNum; i >= startNum; i--)
            {
                if (i % 2 == 0 && i % 3 == 0 && i != adresNum)
                {
                    Console.Write($"{i} ");
                }
                else if (i % 2 == 0 && i % 3 == 0 && i == adresNum)
                {
                    break;
                }
            }
        }
    }
}
