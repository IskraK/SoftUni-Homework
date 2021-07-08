using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbersToCall = Console.ReadLine().Split();
            string[] sitesToVisit = Console.ReadLine().Split();

            foreach (var item in numbersToCall)
            {
                if (item.Length == 7)
                {
                    StationaryPhone stationaryPhone = new StationaryPhone();
                    stationaryPhone.Calling(item);
                }
                else
                {
                    Smartphone smartphone = new Smartphone();
                    smartphone.Calling(item);
                }
            }

            foreach (var item in sitesToVisit)
            {
                Smartphone smartphone = new Smartphone();
                smartphone.Browsing(item);
            }
        }

    }
}
