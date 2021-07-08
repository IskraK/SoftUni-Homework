using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Calling(string number)
        {
            if (!ContainsOnlyDigits(number) && number.Length != 7)
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Dialing... {number}");
            }

        }

        private bool ContainsOnlyDigits(string number)
        {
            foreach (var symbol in number)
            {
                if (!char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
