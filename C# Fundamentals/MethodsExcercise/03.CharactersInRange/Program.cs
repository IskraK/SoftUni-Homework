using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());

            PrinrCharacters(char1, char2);
        }

        private static void PrinrCharacters(char startChar, char endChar)
        {
            if (startChar < endChar)
            {
                for (int i = startChar + 1; i < endChar; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
            else
            {
                for (int i = endChar+1; i < startChar; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
        }
    }
}
