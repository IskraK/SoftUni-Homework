using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace _09.IncreaseAgeStoredProcedure
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string ConnectionString = @"Server=.; Database=MinionsDB; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            int minionId = int.Parse(Console.ReadLine());

            await using (sqlConnection)
            {
                await sqlConnection.OpenAsync();

                string queryProcedure = @"EXEC usp_GetOlder @minionId";
                SqlCommand execProc = new SqlCommand(queryProcedure, sqlConnection);
                execProc.Parameters.AddWithValue("@minionId", minionId);
                await execProc.ExecuteNonQueryAsync();

                string queryPrintMinionInfo = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
                SqlCommand printminionInfo = new SqlCommand(queryPrintMinionInfo, sqlConnection);
                printminionInfo.Parameters.AddWithValue("@Id", minionId);

                SqlDataReader reader = await printminionInfo.ExecuteReaderAsync();

                await using (reader)
                {
                    await reader.ReadAsync();
                    Console.WriteLine($"{reader["Name"]} – {reader["Age"]} years old");
                }
            }
        }
    }
}
