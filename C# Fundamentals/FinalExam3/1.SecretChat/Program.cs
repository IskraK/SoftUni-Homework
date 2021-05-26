using System;
using System.Linq;

namespace _1.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string line = Console.ReadLine();

            while (line != "Reveal")
            {
                string[] parts = line.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                switch (command)
                {
                    case "InsertSpace":
                        //•	InsertSpace:|:{ index}
                        //o Inserts a single empty space at the given index. The given index will always be valid.
                        int index = int.Parse(parts[1]);
                        message = message.Insert(index, " ");
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        //                        •	Reverse:|:{ substring}
                        //                        o If the message contains the given substring, cut it out, reverse it and add it at the end of the message.
                        //o If not, print "error".
                        //o This operation should replace only the first occurrence of the given substring if there are more than one such occurrences.
                        string substr = parts[1];
                        if (message.Contains(substr))
                        {
                            int idx = message.IndexOf(substr);
                            message = message.Remove(idx, substr.Length);
                            substr = new string(substr.ToCharArray().Reverse().ToArray());
                            message = string.Concat(message, substr);
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        //•	ChangeAll:|:{ substring}:|:{ replacement}
                        //o Changes all occurrences of the given substring with the replacement text.
                        string substring = parts[1];
                        string replacement = parts[2];
                        while (message.Contains(substring))
                        {
                            message = message.Replace(substring, replacement);
                        }
                        Console.WriteLine(message);
                        break;
                    default:
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
