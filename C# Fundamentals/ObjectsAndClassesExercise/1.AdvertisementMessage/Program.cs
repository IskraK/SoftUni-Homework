using System;
using System.Collections.Generic;

namespace _1.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phrases = new List<string>()
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };
            List<string> events = new List<string>()
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            List<string> authors = new List<string>()
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };
            List<string> cities = new List<string>()
            { "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            int n = int.Parse(Console.ReadLine());

            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                int idx = rnd.Next(0, n + 1);
                string phrase = phrases[i];
                phrases[i] = phrases[idx];
                phrases[idx] = phrase;

                string currEvent = events[i];
                events[i] = events[idx];
                events[idx] = currEvent;

                string author = authors[i];
                authors[i] = authors[idx];
                authors[idx] = author;

                string city = cities[i];
                cities[i] = cities[idx];
                cities[idx] = city;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{phrases[i]} {events[i]} {authors[i]} – {cities[i]}");
            }
        }
    }
}
