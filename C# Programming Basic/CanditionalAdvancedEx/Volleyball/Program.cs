using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekensHometown = int.Parse(Console.ReadLine());
            double weekensInSofia = 48 - weekensHometown;
            double weekensInSofiaPlay = weekensInSofia*3.0/4.0;
            double hollidaysPlay = holidays * 2.0 / 3.0;
            double weekensPlay = weekensInSofiaPlay + hollidaysPlay + weekensHometown;
            if (year=="leap")
            {
                weekensPlay = weekensPlay * 1.15;
            }
            Console.WriteLine(Math.Floor(weekensPlay));
        }
    }
}
