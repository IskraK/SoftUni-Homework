using MusicHub.Data;
using System;

namespace MusicHub
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MusicHubDbContext context = new MusicHubDbContext();

            context.Database.EnsureCreated();
            Console.WriteLine("MusicHub database created successfully.");
            Console.WriteLine("Do you want to delete the database(Y/N)?");
            string result = Console.ReadLine();
            if (result == "Y")
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
