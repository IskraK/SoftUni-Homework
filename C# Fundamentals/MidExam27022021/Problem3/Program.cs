using System;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceRatings = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int entryPoint = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            int leftSum = 0;
            int rightSum = 0;
            string position = string.Empty;

            if (type == "cheap")
            {
                for (int i = 0; i < entryPoint; i++)
                {
                    if (priceRatings[i] < priceRatings[entryPoint])
                    {
                    leftSum += priceRatings[i];
                    }
                }
                for (int i = entryPoint + 1; i < priceRatings.Length; i++)
                {
                    if (priceRatings[i] < priceRatings[entryPoint])
                    {
                    rightSum += priceRatings[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < entryPoint; i++)
                {
                    if (priceRatings[i] >= priceRatings[entryPoint])
                    {
                        leftSum += priceRatings[i];
                    }
                }
                for (int i = entryPoint + 1; i < priceRatings.Length; i++)
                {
                    if (priceRatings[i] >= priceRatings[entryPoint])
                    {
                        rightSum += priceRatings[i];
                    }
                }
            }

            if (leftSum >= rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }

        }
    }
}
