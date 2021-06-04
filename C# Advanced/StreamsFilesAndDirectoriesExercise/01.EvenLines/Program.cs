using System;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader streamReader = new StreamReader("text.txt");
            int counter = 0;
            string currLine = streamReader.ReadLine();

            while (currLine != null)
            {
                if (counter % 2 == 0)
                {
                    currLine = currLine.Replace('.', '@');
                    currLine = currLine.Replace(',', '@');
                    currLine = currLine.Replace('-', '@');
                    currLine = currLine.Replace('!', '@');
                    currLine = currLine.Replace('?', '@');

                    Console.WriteLine(string.Join(' ', currLine.Split().Reverse()));
                }

                counter++;
                currLine = streamReader.ReadLine();
            }
        }
    }
}
