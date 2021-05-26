using System;

namespace _1.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string line = Console.ReadLine();

            while (line != "Generate")
            {
                string[] parts = line.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                switch (command)
                {
                    case "Contains":
                        string substr = parts[1];
                        if (activationKey.Contains(substr))
                        {
                            Console.WriteLine($"{activationKey} contains {substr}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string uperOrLower = parts[1];
                        int startIdx = int.Parse(parts[2]);
                        int endIdx = int.Parse(parts[3]);
                        string substring = activationKey.Substring(startIdx, endIdx - startIdx);
                        activationKey = activationKey.Remove(startIdx, endIdx - startIdx);
                        if (uperOrLower == "Upper")
                        {
                            substring = substring.ToUpper();
                        }
                        else
                        {
                            substring = substring.ToLower();
                        }
                        activationKey = activationKey.Insert(startIdx,substring);
                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        int startIndex = int.Parse(parts[1]);
                        int endIndex = int.Parse(parts[2]);
                        activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                        Console.WriteLine(activationKey);
                        break;
                    default:
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
