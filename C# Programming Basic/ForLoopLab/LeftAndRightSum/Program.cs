using System;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i < count; i++)
            {
                int currNumber = int.Parse(Console.ReadLine());
                leftSum += currNumber;
            }
            for (int i = 0; i < count; i++)
            {
                int currNumber = int.Parse(Console.ReadLine());
                rightSum += currNumber;
            }
            if (leftSum==rightSum)
            {
                Console.WriteLine($" Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($" No, diff = {Math.Abs(leftSum-rightSum)}");
            }
        }
    }
}
