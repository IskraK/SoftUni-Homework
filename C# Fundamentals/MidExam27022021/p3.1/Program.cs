﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace p3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sentence = Console.ReadLine()
                                   .Split()
                                   .ToList();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Stop")
                {
                    break;
                }

                string[] parts = line.Split();

                string command = parts[0];

                if (command == "Delete")
                {
                    int index = int.Parse(parts[1]);
                    if (index < sentence.Count - 1 && index >= -1)
                    {
                        sentence.RemoveAt(index + 1);
                    }
                }
                else if (command == "Swap")
                {
                    string firstWord = parts[1];
                    string secondWord = parts[2];

                    if (sentence.Contains(firstWord) && sentence.Contains(secondWord))
                    {
                        string temp = firstWord;
                        int firstWordIndex = sentence.IndexOf(firstWord);
                        int secondWordIndex = sentence.IndexOf(secondWord);
                        sentence[firstWordIndex] = secondWord;
                        sentence[secondWordIndex] = temp;
                    }
                }
                else if (command == "Put")
                {
                    string word = parts[1];
                    int index = int.Parse(parts[2]);

                    if (index > 0 && index < sentence.Count-1)
                    {
                        sentence.Insert(index - 1, word);
                    }
                    else if (index == 0)
                    {
                        sentence.Insert(0, word);
                    }
                    else if (index == sentence.Count -1)
                    {
                        sentence.Add(word);
                    }
                }
                else if (command == "Sort")
                {
                    sentence.Sort();
                    sentence.Reverse();
                }
                else if (command == "Replace")
                {
                    string firstWord = parts[1];
                    string secondWord = parts[2];

                    for (int i = 0; i < sentence.Count; i++)
                    {
                        if (sentence[i].Contains(secondWord))
                            sentence[i] = firstWord;
                    }
                }
            }
            Console.Write(string.Join(" ", sentence));
        }
    }
}
