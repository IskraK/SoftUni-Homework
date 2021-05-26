using System;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
           
                int numberOfWords = int.Parse(Console.ReadLine());
            string words = "";

            for (int i = 0; i < numberOfWords; i++)
            {
                int number = int.Parse(Console.ReadLine());
                int lastDigit = number % 10;
                int length = number.ToString().Length;
                string letter="";
                switch (lastDigit)
                {
                    case 2:
                        if (length==1)
                        {
                            letter = "a";
                        }
                        else if (length == 2)
                        {
                            letter = "b";
                        }
                        else
                        {
                            letter = "c";
                        }
                        break;
                    case 3:
                        if (length == 1)
                        {
                            letter = "d";
                        }
                        else if (length == 2)
                        {
                            letter = "e";
                        }
                        else
                        {
                            letter = "f";
                        }
                        break;
                    case 4:
                        if (length == 1)
                        {
                            letter = "g";
                        }
                        else if (length == 2)
                        {
                            letter = "h";
                        }
                        else
                        {
                            letter = "i";
                        }
                        break;
                    case 5:
                        if (length == 1)
                        {
                            letter = "j";
                        }
                        else if (length == 2)
                        {
                            letter = "k";
                        }
                        else
                        {
                            letter = "l";
                        }
                        break;
                    case 6:
                        if (length == 1)
                        {
                            letter = "m";
                        }
                        else if (length == 2)
                        {
                            letter = "n";
                        }
                        else
                        {
                            letter = "o";
                        }
                        break;
                    case 7:
                        if (length == 1)
                        {
                            letter = "p";
                        }
                        else if (length == 2)
                        {
                            letter = "q";
                        }
                        else if (length == 3)
                        {
                            letter = "r";
                        }
                        else
                        {
                            letter = "s";
                        }
                        break;
                    case 8:
                        if (length == 1)
                        {
                            letter = "t";
                        }
                        else if (length == 2)
                        {
                            letter = "u";
                        }
                        else
                        {
                            letter = "v";
                        }
                        break;
                    case 9:
                        if (length == 1)
                        {
                            letter = "w";
                        }
                        else if (length == 2)
                        {
                            letter = "x";
                        }
                        else if (length == 3)
                        {
                            letter = "y";
                        }
                        else
                        {
                            letter = "z";
                        }
                        break;
                    default:
                        letter = " ";
                        break;
                }
                words += string.Concat(letter);
            }
                Console.Write(words);
        }
    }
}
