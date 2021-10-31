using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext dbContext = new FootballBettingContext();

            dbContext.Database.Migrate();

            Console.WriteLine("DB created successfully");
        }
    }
}
