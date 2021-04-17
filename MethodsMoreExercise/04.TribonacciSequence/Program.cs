using System;

namespace _04.TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] arr = new int[num];

            Console.WriteLine(string.Join(" ",GetTribonacci(num)));
        }

        private static int[] GetTribonacci(int num)
        {
            int[] numbers = new int[num];
            
            for (int i = 0; i < num; i++)
            {
                if (i == 0 || i == 1)
                {
                    numbers[i] = 1;
                }
                else if (i == 2)
                {
                    numbers[i] = 2;
                }
                else
                {
                numbers[i] = numbers[i - 1] + numbers[i - 2] + numbers[i - 3];
                }
            }
                return numbers;
            
        }
    }
}
