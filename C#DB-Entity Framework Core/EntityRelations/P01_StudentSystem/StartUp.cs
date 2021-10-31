using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var dbContext = new StudentSystemContext();

            dbContext.Database.EnsureCreated();

            Console.WriteLine("DB created successfully");
            Console.WriteLine("Do you want to delete the database(Y/N)?");
            string result = Console.ReadLine();
            if (result == "Y")
            {
            dbContext.Database.EnsureDeleted();
            }

        }
    }
}
