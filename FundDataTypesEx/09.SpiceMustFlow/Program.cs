using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int countDays = 0;
            int totalSpiece = 0;

            while (yield >= 100)
            {
                totalSpiece += yield;
                countDays++;
                yield -= 10;
                if (totalSpiece >= 26)
                {
                totalSpiece -= 26;
                }
                else
                {
                    totalSpiece = 0;
                }
            }


            if (totalSpiece >= 26)
            {
                totalSpiece -= 26;
            }
            else
            {
                totalSpiece = 0;
            }
            Console.WriteLine(countDays);
            Console.WriteLine(totalSpiece);
        }
    }
}
