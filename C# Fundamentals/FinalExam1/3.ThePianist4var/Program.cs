using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ThePianist4var
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Piece> pieces = new List<Piece>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currPiece = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                Piece piece = new Piece(currPiece[0], currPiece[1], currPiece[2]);
                pieces.Add(piece);
            }

            string[] command = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Stop")
            {
                if (command[0] == "Add")
                {
                    if (pieces.Any(p => p.Name == command[1]))
                    {
                        Console.WriteLine($"{command[1]} is already in the collection!");
                    }
                    else
                    {
                        Piece piece = new Piece(command[1], command[2], command[3]);
                        pieces.Add(piece);
                        Console.WriteLine($"{command[1]} by {command[2]} in {command[3]} added to the collection!");
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (pieces.Any(p => p.Name == command[1]))
                    {
                        var item = pieces.SingleOrDefault(p => p.Name == command[1]);
                        pieces.Remove(item);
                        Console.WriteLine($"Successfully removed {command[1]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
                    }
                }
                else if (command[0] == "ChangeKey")
                {
                    if (pieces.Any(p => p.Name == command[1]))
                    {
                        var item = pieces.SingleOrDefault(p => p.Name == command[1]);
                        int index = pieces.IndexOf(item);
                        pieces[index].Key = command[2];
                        Console.WriteLine($"Changed the key of {command[1]} to {command[2]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
                    }
                }

                command = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            }

            pieces = pieces
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Composer)
                .ToList();

            foreach (var item in pieces)
            {
                Console.WriteLine($"{item.Name} -> Composer: {item.Composer}, Key: {item.Key}");
            }
        }
        class Piece
        {
            public Piece(string name, string composer, string key)
            {
                Name = name;
                Composer = composer;
                Key = key;
            }
            public string Name { get; set; }
            public string Composer { get; set; }
            public string Key { get; set; }
        }
    }
}
