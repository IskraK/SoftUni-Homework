using System;

namespace StreamOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string word = "";
            int counterC = 0;
            int counterO = 0;
            int counterN = 0;
            while (input != "End")
            {
                if (input == "c" && counterC == 0)
                {
                    counterC++;
                }
                else if (input == "c" && counterC >= 1)
                {
                    word += input;
                }

                if (input == "o" && counterO == 0)
                {
                    counterO++;
                }
                else if (input == "o" && counterO >= 1)
                {
                    word += input;
                }
                if (input == "n" && counterN == 0)
                {
                    counterN++;
                }
                else if (input == "n" && counterN >= 1)
                {
                    word += input;
                }
                if (input == "a" || input == "b" || input == "d" || input == "e" || input == "f" || input == "g" || input == "h" || input == "i" || input == "j" || input == "k" || input == "l" || input == "m" || input == "p" || input == "q" || input == "r" || input == "s" || input == "t" || input == "u" || input == "v" || input == "w" || input == "x" || input == "y" || input == "z" || input == "A" || input == "B" || input == "D" || input == "E" || input == "F" || input == "G" || input == "H" || input == "I" || input == "J" || input == "K" || input == "L" || input == "M" || input == "P" || input == "Q" || input == "R" || input == "S" || input == "T" || input == "U" || input == "V" || input == "W" || input == "X" || input == "Y" || input == "Z" || input == "C" || input == "O" || input == "N")
                {
                    word += input;
                }
                if (counterC == 1 && counterO == 1 && counterN == 1)
                {
                    word = word + " ";
                    Console.Write($"{word}");
                    counterC = 0;
                    counterO = 0;
                    counterN = 0;
                    word = "";
                }
                input = Console.ReadLine();
            }
        }
    }
}
