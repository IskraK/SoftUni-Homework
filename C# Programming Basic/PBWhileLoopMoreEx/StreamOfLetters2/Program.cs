using System;

namespace StreamOfLetters2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            string input = Console.ReadLine();
            int countInputCharC = 0;
            int countInputCharO = 0;
            int countInputCharN = 0;
            string currWord = "";
            string outputText = "";

            while (input != "End")
            {
                if (allowedChars.Contains(input))
                {
                    switch (input)
                    {
                        case "c":
                            countInputCharC++;
                            if (countInputCharC > 1)
                            {
                                currWord += input;
                            }
                            break;
                        case "o":
                            countInputCharO++;
                            if (countInputCharO > 1)
                            {
                                currWord += input;
                            }
                            break;
                        case "n":
                            countInputCharN++;
                            if (countInputCharN > 1)
                            {
                                currWord += input;
                            }
                            break;
                        default:
                            currWord += input;
                            break;
                    }
                    if (countInputCharC > 0 && countInputCharN > 0 && countInputCharO > 0)
                    {
                        countInputCharC = countInputCharN = countInputCharO = 0;
                        outputText += currWord + " ";
                        currWord = "";
                    }
                }
                input = Console.ReadLine();
            }

            Console.Write(outputText);
        }
    }
}
