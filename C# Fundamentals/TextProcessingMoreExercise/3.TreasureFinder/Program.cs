using System;
using System.Linq;
using System.Text;

namespace _3.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string text = Console.ReadLine();


            while (text != "find")
            {
                StringBuilder result = new StringBuilder();
                int keyIdx = 0;

                foreach (var item in text)
                {
                    if (keyIdx > key.Length - 1)
                    {
                        keyIdx = 0;
                    }

                    char decryptedChar = (char)(item - key[keyIdx]);
                    keyIdx++;
                    result.Append(decryptedChar);
                }

                string message = result.ToString();

                int startIdxTreasure = message.IndexOf('&');
                int endIdxTreasure = message.LastIndexOf('&');
                string treasure = message.Substring(startIdxTreasure + 1, endIdxTreasure - startIdxTreasure - 1);

                int startIdxCoordinates = message.IndexOf('<');
                int endIdxCoordinates = message.LastIndexOf('>');
                string coordinates = message.Substring(startIdxCoordinates + 1, endIdxCoordinates - startIdxCoordinates - 1);

                Console.WriteLine($"Found {treasure} at {coordinates}");

                text = Console.ReadLine();
            }
        }
    }
}
