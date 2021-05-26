using System;

namespace _01.EncryptSortPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            const string allVowels = "aoueiAOUEI";
            int numberOfStrings = int.Parse(Console.ReadLine());
            int[] encryptString = new int[numberOfStrings];

            for (int i = 0; i < numberOfStrings; i++)
            {
                string word = Console.ReadLine();
                for (int j = 0; j < word.Length; j++)
                {
                    if (allVowels.Contains(word[j]))
                    {
                        encryptString[i] += (int)word[j] * word.Length;
                    }
                    else
                    {
                        encryptString[i] += (int)word[j] / word.Length;
                    }
                }
            }
            Array.Sort(encryptString);
            //Console.WriteLine(string.Join(Environment.NewLine, encryptString));
            foreach (var item in encryptString)
            {
                Console.WriteLine(item);
            }
        }
    }
}
