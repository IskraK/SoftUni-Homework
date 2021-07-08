using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public void Browsing(string site)
        {
            if (site.Any(c => char.IsDigit(c)))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {site}!");
            }
            
        }

        public void Calling(string number)
        {
            if (!number.All(c => char.IsDigit(c)))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {number}");
            }
            
        }

    }
}
