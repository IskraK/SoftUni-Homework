using System;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string encryptedText = string.Empty;

            foreach (var ch in text)
            {
                encryptedText += (char)(ch + 3);
            }

            Console.WriteLine(encryptedText);
        }
    }
}
