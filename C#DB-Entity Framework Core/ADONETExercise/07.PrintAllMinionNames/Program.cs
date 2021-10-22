using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _07.PrintAllMinionNames
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string ConnectionString = @"Server=.; Database=MinionsDB; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            List<string> minions = new List<string>();

            using (sqlConnection)
            {
                await sqlConnection.OpenAsync();

                string queryMinions = @"SELECT Name FROM Minions";
                SqlCommand getMinionsNames = new SqlCommand(queryMinions, sqlConnection);
                SqlDataReader sqlDataReader = await getMinionsNames.ExecuteReaderAsync();

                await using (sqlDataReader)
                {
                    while (await sqlDataReader.ReadAsync())
                    {
                        minions.Add(sqlDataReader[0] as string);
                    }
                }
            }

            for (int i = 0; i < minions.Count/2; i++)
            {
                Console.WriteLine(minions[i]);
                Console.WriteLine(minions[minions.Count-1-i]);
            }

            if (minions.Count % 2 == 1)
            {
                Console.WriteLine(minions[minions.Count/2]);
            }
        }
    }
}
