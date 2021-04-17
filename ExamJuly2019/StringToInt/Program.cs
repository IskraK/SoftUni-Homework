using System;

namespace StringToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "Iskra";
            Console.WriteLine(word.Length);
            Console.WriteLine(word[2]);
            Console.WriteLine((int)word[2]);
            int sum = 0;
            for (int i = 0; i < word.Length; i++)
            {
                sum += (int)word[i];
            }
            Console.WriteLine(sum);
        }
    }
}
