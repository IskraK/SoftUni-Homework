using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ThePianist3var
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PieceInfo> pieces = new Dictionary<string, PieceInfo>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                string pieceName = input[0];
                string composer = input[1];
                string key = input[2];

                pieces.Add(pieceName, new PieceInfo { Composer = composer, Key = key });
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
                            pieces.Add(pieceName, new PieceInfo { Composer=composer,Key=key});
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
                            pieces[pieceName].Key = newKey;
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

            pieces = pieces
                .OrderBy(p => p.Key)
                .ThenBy(p => p.Value.Composer)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }

    internal class PieceInfo
    {
        public string Composer { get; set; }
        public string Key { get; set; }
    }
}
