using System;
using System.Linq;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string line = Console.ReadLine();

            while (line != "Sign up")
            {
                string[] parts = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                switch (command)
                {
                    case "Case":
                        string lowerOrUpper = parts[1];
                        if (lowerOrUpper == "lower")
                        {
                            username = username.ToLower();
                        }
                        else
                        {
                            username = username.ToUpper();
                        }
                        Console.WriteLine(username);
                        break;
                    case "Reverse":
                        int startIdx = int.Parse(parts[1]);
                        int endtIdx = int.Parse(parts[2]);
                        if (startIdx >= 0 && startIdx < endtIdx && endtIdx < username.Length)
                        {
                            string substring = username.Substring(startIdx, endtIdx - startIdx + 1);
                            substring = string.Concat(substring.Reverse());
                            Console.WriteLine(substring);
                        }
                        break;
                    case "Cut":
                        string substr = parts[1];
                        if (username.Contains(substr))
                        {
                            int index = username.IndexOf(substr);
                            username = username.Remove(index,substr.Length);
                            Console.WriteLine(username);
                        }
                        else
                        {
                            Console.WriteLine($"The word {username} doesn't contain {substr}.");
                        }
                        break;
                    case "Replace":
                        char symbol = char.Parse(parts[1]);
                        username = username.Replace(symbol, '*');
                        Console.WriteLine(username);
                        break;
                    case "Check":
                        char ch = char.Parse(parts[1]);
                        if (username.Contains(ch))
                        {
                            Console.WriteLine("Valid");
                        }
                        else
                        {
                            Console.WriteLine($"Your username must contain {ch}.");
                        }
                        break;
                    default:
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }
}
