using System;
using System.Linq;
using System.Text;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {

                string reversed = ReverseSB(input);

                if (string.Compare(input, reversed) == 0)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                input = Console.ReadLine();
            }
        }

        public static string ReverseSB(string text)
        {
            StringBuilder builder = new StringBuilder(text.Length);
            for (int i = text.Length - 1; i >= 0; i--)
            {
                builder.Append(text[i]);
            }
            return builder.ToString();
        }
    }
}
