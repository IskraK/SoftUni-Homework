using System;

namespace _08.TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int row = 1;
            int currNumber = 1;
            bool isEqual = false;
            while (isEqual == false)
            {

                for (int i = 1; i <= row; i++)
                {
                    Console.Write($"{currNumber} ");
                }
                currNumber++;
                if (currNumber > n)
                {
                    isEqual = true;
                    break;
                }
                Console.WriteLine();
                row++;
            }
        }
    }
}
