using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int smallestNum = int.MaxValue;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                int num = int.Parse(input);
                if (num < smallestNum)
                {
                    smallestNum = num;
                }
            }

            Console.WriteLine(smallestNum);
        }
    }
}
