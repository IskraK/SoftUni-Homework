using System;

namespace StreamOfLetters4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool nIsAppeared = false;
            bool cIsAppeared = false;
            bool oIsAppeared = false;

            string printLine = "";
            string newWord = "";

            string letter = Console.ReadLine();

            while (letter != "End")
            {
                char currentLetter = letter[0];

                if (char.IsLetter(currentLetter))
                {
                    if (currentLetter == 'n')
                    {
                        if (nIsAppeared)
                        {
                            newWord += letter;
                        }
                        nIsAppeared = true;
                    }
                    else if (currentLetter == 'c')
                    {
                        if (cIsAppeared)
                        {
                            newWord += letter;
                        }
                        cIsAppeared = true;
                    }
                    else if (currentLetter == 'o')
                    {
                        if (oIsAppeared)
                        {
                            newWord += letter;
                        }
                        oIsAppeared = true;
                    }
                    else
                    {
                        newWord += letter;
                    }

                    if (nIsAppeared && cIsAppeared && oIsAppeared)
                    {
                        printLine += $"{newWord} ";
                        newWord = "";
                        nIsAppeared = false;
                        cIsAppeared = false;
                        oIsAppeared = false;
                    }
                }

                letter = Console.ReadLine();
            }

            Console.WriteLine(printLine);
        }
    }
}
