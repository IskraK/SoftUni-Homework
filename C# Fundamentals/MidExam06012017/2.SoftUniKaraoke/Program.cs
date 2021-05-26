using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SoftUniKaraoke
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine()
                .Split(", ")
                .ToList();
            List<string> songs = Console.ReadLine()
                .Split(", ")
                .ToList();
            string input = Console.ReadLine();

            while (input != "dawn")
            {
                string[] line = input.Split(", ");
                string name = line[0];
                string song = line[1];
                string award = line[2];

                List<string> awards = new List<string>(participants.Count);
                List<int> countAwards = new List<int>(participants.Count);
                for (int i = 0; i < participants.Count; i++)
                {
                    if (participants.Contains(name) && songs.Contains(song))
                    {
                        awards[i] =award ;
                        countAwards[i]+=1;
                    }
                }
                input = Console.ReadLine();
            }

            //решава се с речници и ламбда - не е за midExam
        }
    }
}
