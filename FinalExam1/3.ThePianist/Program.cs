using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPieces = int.Parse(Console.ReadLine());
            List<Piece> pieces = new List<Piece>(numberPieces);

            for (int i = 0; i < numberPieces; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                string pieceName = input[0];
                string composer = input[1];
                string key = input[2];

                Piece piece = new Piece(pieceName, composer, key);
                pieces.Add(piece);
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
                        Piece piece = new Piece(pieceName, composer, key);
                        if (pieces.Contains(piece))
                        {
                            Console.WriteLine($"{pieceName} is already in the collection!");
                        }
                        else
                        {
                            pieces.Add(piece);
                            Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                        }
                        break;
                    case "Remove":
                        bool isRemoved = false;
                        foreach (Piece item in pieces.ToList())
                        {
                            if (item.Name == pieceName)
                            {
                                pieces.Remove(item);
                                isRemoved = true;
                            }
                        }
                        if (isRemoved)
                        {
                            Console.WriteLine($"Successfully removed {pieceName}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        }

                        break;
                    case "ChangeKey":
                        string newKey = parts[2];
                        bool isChanged = false;
                        foreach (Piece item in pieces.ToList())
                        {
                            if (item.Name == pieceName)
                            {
                                item.Key = newKey;
                                isChanged = true;
                            }
                        }
                        if (isChanged)
                        {
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

            List<Piece> sortedPieces = pieces
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Composer)
                .ToList();

            foreach (Piece item in sortedPieces)
            {
                Console.WriteLine(item);
            }
            //83/100, но работи вярно!!!
        }
    }
    public class Piece
    {
        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

        public Piece(string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            Key = key;
        }
        public override string ToString()
        {
            return $"{Name} -> Composer: {Composer}, Key: {Key}";
        }
    }
}
