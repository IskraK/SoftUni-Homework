using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string result = GetMiddleElement(input);

            Console.WriteLine(result);
        }

        private static string GetMiddleElement(string str)
        {
            if (str.Length % 2 != 0)
            {
                return str[str.Length / 2].ToString();
            }
            else
            {
                return str[str.Length / 2 - 1].ToString()+str[str.Length / 2].ToString();
            }
        }
    }
}
