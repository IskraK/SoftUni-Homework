using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _08.IncreaseMinionAge
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string ConnectionString = @"Server=.; Database=MinionsDB; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            int[] minionsId = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


            await using (sqlConnection)
            {
                await sqlConnection.OpenAsync();

                foreach (var id in minionsId)
                {
                    string queryIncreaseAge = @"UPDATE Minions
                                                SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                                WHERE Id = @Id";

                    SqlCommand increaseAgeCmd = new SqlCommand(queryIncreaseAge, sqlConnection);
                    increaseAgeCmd.Parameters.AddWithValue("@Id", id);
                    await increaseAgeCmd.ExecuteNonQueryAsync();

                    string queryPrintMinionInfo = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
                    SqlCommand printMinionInfo = new SqlCommand(queryPrintMinionInfo, sqlConnection);
                    printMinionInfo.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = await printMinionInfo.ExecuteReaderAsync();

                    await using (reader)
                    {
                        await reader.ReadAsync();
                        Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                    }
                }
            }
        }
    }
}
