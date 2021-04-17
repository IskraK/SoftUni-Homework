using System;

namespace VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            //буква       a   e   i   o   u
            //стойност    1   2   3   4   5
            string text = Console.ReadLine();
            int sumVolews = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                switch (letter)
                {
                    case 'a':
                        sumVolews += 1;
                        break;
                    case 'e':
                        sumVolews += 2;
                        break;
                    case 'i':
                        sumVolews += 3;
                        break;
                    case 'o':
                        sumVolews += 4;
                        break;
                    case 'u':
                        sumVolews += 5;
                        break;
                }
            }
            Console.WriteLine(sumVolews);
        }
    }
}
