using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int biggestNum = int.MinValue;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                int num = int.Parse(input);
                if (num > biggestNum)
                {
                    biggestNum = num;
                }
            }

            Console.WriteLine(biggestNum);
        }
    }
}
