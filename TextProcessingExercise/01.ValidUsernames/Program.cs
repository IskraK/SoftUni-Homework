using System;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in input)
            {
                if (word.Length >= 3 && word.Length <= 16)
                {
                    bool isValidSymbol = true;

                    foreach (var symbol in word)
                    {
                        
                        if (!char.IsLetterOrDigit(symbol) && symbol != '-' && symbol != '_')
                        {
                            isValidSymbol = false;
                        }
                    }

                    if (isValidSymbol == true)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}
