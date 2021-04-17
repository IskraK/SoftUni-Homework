using System;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int maxNum = int.MinValue;
            int midNum = int.MinValue;
            int minNum = int.MaxValue;

            if (num1 > num2)
            {
                if (num1 > num3)
                {
                    maxNum = num1;
                    if (num2 > num3)
                    {
                        midNum = num2;
                        minNum = num3;
                    }
                    else
                    {
                        midNum = num3;
                        minNum = num2;
                    }
                }
                else
                {
                    maxNum = num3;
                    midNum = num1;
                    minNum = num2;
                }
            }
            else
            {
                if (num2 < num3)
                {
                    minNum = num1;
                    midNum = num2;
                    maxNum = num3;
                }
                else
                {
                    maxNum = num2;
                    if (num1 > num3)
                    {
                        midNum = num1;
                        minNum = num3;
                    }
                    else
                    {
                        minNum = num1;
                        midNum = num3;
                    }
                }
            }
            Console.WriteLine(maxNum);
            Console.WriteLine(midNum);
            Console.WriteLine(minNum);
        }
    }
}
