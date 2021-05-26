using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat2var
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string[] currCommand = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (currCommand[0])
                {
                    case "merge":
                        int startIndex = int.Parse(currCommand[1]);
                        int endIndex = int.Parse(currCommand[2]);
                        MergeElements(line, startIndex, endIndex);
                        break;
                    case "divide":
                        int index = int.Parse(currCommand[1]);
                        int partitions = int.Parse(currCommand[2]);
                        DivideElements(line, index, partitions);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", line));
        }

        private static void DivideElements(List<string> listOfStrings, int index, int partitions)
        {
            string element = listOfStrings[index];
            listOfStrings.RemoveAt(index);
            int substringsLength = element.Length / partitions;
            int lastSubstringsLength = element.Length % partitions + element.Length / partitions;

            for (int i = 0; i < partitions; i++, index++)
            {
                string currSubString = element.Substring(i * substringsLength, substringsLength);
                if (i == partitions - 1)
                {
                    currSubString = element.Substring(i * substringsLength, lastSubstringsLength);
                }

                listOfStrings.Insert(index, currSubString);
            }
        }

        private static void MergeElements(List<string> listOfStrings, int startIndex, int endIndex)
        {
            if (startIndex > listOfStrings.Count - 1)
            {
                return; //if startIndex is out of list
            }

            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex > listOfStrings.Count - 1)
            {
                endIndex = listOfStrings.Count - 1;
            }

            List<string> elements = listOfStrings.GetRange(startIndex, endIndex - startIndex + 1);
            listOfStrings.RemoveRange(startIndex, endIndex - startIndex + 1);
            listOfStrings.Insert(startIndex, string.Join("", elements));
        }
    }
}
