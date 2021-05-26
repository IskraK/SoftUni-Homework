using System;
using System.Text;

namespace _04.CaesarCipherSB
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder encryptedText = new StringBuilder();

            foreach (var symbol in text)
            {
                encryptedText.Append((char)(symbol + 3));
            }

            Console.WriteLine(encryptedText);
        }
    }
}
