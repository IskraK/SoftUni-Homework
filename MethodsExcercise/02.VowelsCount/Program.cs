using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintVowelsCount(input);
        }

        private static void PrintVowelsCount(string str)
        {
            const string allVowels= "aoueiAOUEI";
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (allVowels.Contains(str[i]))
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
