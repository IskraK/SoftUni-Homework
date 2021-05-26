using System;

namespace _1.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                int startIdxName = input.IndexOf('@');
                int endIdxName = input.IndexOf('|');
                string name = input.Substring(startIdxName + 1, endIdxName - startIdxName-1);

                int startIdxAge = input.IndexOf('#');
                int endIdxAge = input.IndexOf('*');
                string age = input.Substring(startIdxAge + 1, endIdxAge - startIdxAge-1);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
