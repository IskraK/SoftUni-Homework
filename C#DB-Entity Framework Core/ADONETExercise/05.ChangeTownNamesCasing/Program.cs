using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string ConnectionString = @"Server=.; Database=MinionsDB; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            await sqlConnection.OpenAsync();

            string country = Console.ReadLine();

            await using (sqlConnection)
            {
                await ChangeTownNamesCasingAsync(sqlConnection,country);
            }

        }

        private static async Task ChangeTownNamesCasingAsync(SqlConnection sqlConnection, string country)
        {
            string queryCountryId = @"SELECT Id FROM Countries WHERE Name = @countryName";
            SqlCommand getCountryIdCmd = new SqlCommand(queryCountryId, sqlConnection);
            getCountryIdCmd.Parameters.AddWithValue("@countryName", country);

            object countryIdObject = await getCountryIdCmd.ExecuteScalarAsync();

            if (countryIdObject == null)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            int countryCode = (int)countryIdObject;

            string queryUpdateTownsNames = @"UPDATE Towns
                                             SET Name = UPPER(Name)
                                             WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
            SqlCommand updateTownNameCmd = new SqlCommand(queryUpdateTownsNames, sqlConnection);
            updateTownNameCmd.Parameters.AddWithValue("@countryName", country);

            int affectedRows = await updateTownNameCmd.ExecuteNonQueryAsync();
            if (affectedRows == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            Console.WriteLine($"{affectedRows} town names were affected.");

            List<string> towns = new List<string>();


            string queryTownName = @"SELECT Name FROM Towns WHERE CountryCode = @countryCode";
            SqlCommand getTownNameCmd = new SqlCommand(queryTownName, sqlConnection);
            getTownNameCmd.Parameters.AddWithValue("@countryCode", countryCode);

            SqlDataReader sqlDataReader = await getTownNameCmd.ExecuteReaderAsync();

            await using (sqlDataReader)
            {
                while (await sqlDataReader.ReadAsync())
                {
                    towns.Add((string)sqlDataReader[0]);
                }
            }

            Console.WriteLine($"[{String.Join(", ",towns)}]");
        }
    }
}
