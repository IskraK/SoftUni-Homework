using System;
using System.Text;

namespace _1.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.Append(message);

            while (input != "Decode")
            {
                string[] commandLine = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = commandLine[0];

                switch (command)
                {
                    case "Move":
                        int numberLetters = int.Parse(commandLine[1]);
                        string substr = sb.ToString().Substring(0, numberLetters);
                        sb.Append(substr);
                        sb.Remove(0, numberLetters);
                        break;
                    case "Insert":
                        int idx = int.Parse(commandLine[1]);
                        string value = commandLine[2];
                        sb.Insert(idx, value);
                        break;
                    case "ChangeAll":
                        string substring = commandLine[1];
                        string replacement = commandLine[2];
                        sb.Replace(substring, replacement);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {sb}");
        }
    }
}
