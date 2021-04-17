using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Songs2var
{
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>(numberOfSongs);

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] data = Console.ReadLine()
                    .Split("_", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = data[0];
                string name = data[1];
                string time = data[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }

            string typeList = Console.ReadLine();


            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                List<Song> filteredSongs = songs.Where(s => s.TypeList == typeList).ToList();

                foreach (Song song in filteredSongs)
                {
                    Console.WriteLine(song.Name);
                }

            }
        }
    }
}
