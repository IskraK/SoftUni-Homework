using System;

namespace _05.DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int message = 0;
            string decryptMessage = "";
            for (int i = 1; i <= n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                message= letter + key;
                decryptMessage += (char)message;
            }

            Console.WriteLine(decryptMessage);
        }
    }
}
