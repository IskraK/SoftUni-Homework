using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ThePianist2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPieces = int.Parse(Console.ReadLine());
            Dictionary<string, string[]> pieces = new Dictionary<string, string[]>(numberPieces);

            for (int i = 0; i < numberPieces; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                string pieceName = input[0];
                string composer = input[1];
                string key = input[2];

                pieces.Add(pieceName, new string[2]);
                pieces[pieceName][0] = composer;
                pieces[pieceName][1] = key;
            }

            string line = Console.ReadLine();

            while (line != "Stop")
            {
                string[] parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string pieceName = parts[1];

                switch (command)
                {
                    case "Add":
                        string composer = parts[2];
                        string key = parts[3];
                        
                        if (pieces.ContainsKey(pieceName))
                        {
                            Console.WriteLine($"{pieceName} is already in the collection!");
                        }
                        else
                        {
                            pieces.Add(pieceName,new string[2]);
                            pieces[pieceName][0] = composer;
                            pieces[pieceName][1] = key;
                            Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                        }
                        break;
                    case "Remove":
                        
                            if (pieces.ContainsKey(pieceName))
                            {
                                pieces.Remove(pieceName);
                                Console.WriteLine($"Successfully removed {pieceName}!");
                            }
                            else
                            {
                                Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                            }
                        break;
                    case "ChangeKey":
                        string newKey = parts[2];
                            if (pieces.ContainsKey(pieceName))
                            {
                                pieces[pieceName][1] = newKey;
                                Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
                            }
                            else
                            {
                                Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                            }
                        break;
                    default:
                        break;
                }

                line = Console.ReadLine();
            }

            Dictionary<string, string[]> sortedPieces = pieces
                .OrderBy(x => x.Key)
                .ThenBy(x => x.Value[0])
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sortedPieces)
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}
