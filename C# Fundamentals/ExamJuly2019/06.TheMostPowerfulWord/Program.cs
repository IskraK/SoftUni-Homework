using System;

namespace _06.TheMostPowerfulWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            double totalSum = 0;
            double maxSum = 0;
            string maxWord = "";
            while (word != "End of words")
            {
                for (int i = 0; i < word.Length; i++)
                {
                    totalSum += (int)word[i];
                }
                int length = word.Length;
                if (word[0] == 'a' || word[0] == 'A' || word[0] == 'e' || word[0] == 'E' || word[0] == 'i' || word[0] == 'I' || word[0] == 'o' || word[0] == 'O' || word[0] == 'u' || word[0] == 'U' || word[0] == 'y' || word[0] == 'Y')
                {
                    totalSum *= length;
                }
                else
                {
                    totalSum = Math.Floor(totalSum / length);
                }
                if (totalSum > maxSum)
                {
                    maxSum = totalSum;
                    maxWord = word;
                }
                word = Console.ReadLine();
                totalSum = 0;
            }
            Console.WriteLine($"The most powerful word is {maxWord} - {maxSum}");
        }
    }
}
