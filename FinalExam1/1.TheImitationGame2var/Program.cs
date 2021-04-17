using System;

namespace _1.TheImitationGame2var
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Decode")
            {
                string[] commandLine = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = commandLine[0];

                switch (command)
                {
                    case "Move":
                        int numberLetters = int.Parse(commandLine[1]);
                        string substr = message.Substring(0, numberLetters);
                        message = string.Concat(message, substr);
                        message=message.Remove(0, numberLetters);
                        break;
                    case "Insert":
                        int idx = int.Parse(commandLine[1]);
                        string value = commandLine[2];
                        message=message.Insert(idx, value);
                        break;
                    case "ChangeAll":
                        string substring = commandLine[1];
                        string replacement = commandLine[2];
                        message=message.Replace(substring, replacement);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
