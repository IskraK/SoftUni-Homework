using System;

namespace _1.Nikulden_sCharity
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string line = Console.ReadLine();

            while (line != "Finish")
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                switch (command)
                {
                    case "Replace":
                        char currChar = char.Parse(parts[1]);
                        char newChar = char.Parse(parts[2]);
                        message = message.Replace(currChar, newChar);
                        Console.WriteLine(message);
                        break;
                    case "Cut":
                        int startIdx = int.Parse(parts[1]);
                        int endIdx = int.Parse(parts[2]);
                        if (startIdx < 0 || startIdx > endIdx || endIdx > message.Length || startIdx > message.Length || endIdx < 0)
                        {
                            Console.WriteLine("Invalid indexes!");
                        }
                        else
                        {
                            message = message.Remove(startIdx, endIdx - startIdx + 1);
                            Console.WriteLine(message);
                        }
                        break;
                    case "Make":
                        string upperOrLower = parts[1];

                        if (upperOrLower == "Upper")
                        {
                            message = message.ToUpper();
                        }
                        else if (upperOrLower == "Lower")
                        {
                            message = message.ToLower();
                        }

                        Console.WriteLine(message);
                        break;
                    case "Check":
                        string str = parts[1];

                        if (message.Contains(str))
                        {
                            Console.WriteLine($"Message contains {str}");
                        }
                        else
                        {
                            Console.WriteLine($"Message doesn't contain {str}");
                        }
                        break;
                    case "Sum":
                        int startIndex = int.Parse(parts[1]);
                        int endIndex = int.Parse(parts[2]);

                        if (startIndex < 0 || startIndex > endIndex || endIndex > message.Length || startIndex > message.Length || endIndex < 0)
                        {
                            Console.WriteLine("Invalid indexes!");
                        }
                        else
                        {
                            string substr = message.Substring(startIndex, endIndex - startIndex + 1);
                            int sum = 0;
                            for (int i = 0; i < substr.Length; i++)
                            {
                                sum += (int)substr[i];
                            }
                            Console.WriteLine(sum);
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
