using System;
using System.Text;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string result = RepeatString(input, count);
            Console.WriteLine(result);
        }

        private static string RepeatString(string str, int count)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                result.Append(str);
            }

            return result.ToString();

            //2 variant
            //string result = null;
            //for (int i = 0; i < count; i++)
            //{
            //    result += str;
            //}
            //return result;
        }
    }
}
