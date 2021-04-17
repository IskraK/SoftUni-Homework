using System;

namespace _06.TheMostPowerfulWordAutor
{
    class Program
    {
        static void Main(string[] args)
        {
            string mostPowerfulWord = "";
            double maxPower = 0;

            string input = "";
            while ("End of words" != (input = Console.ReadLine()))
            {
                double inputSum = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    inputSum += input[i];
                }

                int numLength = input.Length;
                string input2 = input.ToLower();
                if (input2[0] == 'a'
                        || input2[0] == 'e'
                        || input2[0] == 'i'
                        || input2[0] == 'o'
                        || input2[0] == 'u'
                        || input2[0] == 'y')
                {
                    inputSum = inputSum * numLength;
                }
                else
                {
                    inputSum = Math.Floor(inputSum / numLength);
                }

                if (inputSum > maxPower)
                {
                    maxPower = inputSum;
                    mostPowerfulWord = input;
                }
            }

            Console.WriteLine($"The most powerful word is {mostPowerfulWord} - {maxPower}");
        }
    }
}
