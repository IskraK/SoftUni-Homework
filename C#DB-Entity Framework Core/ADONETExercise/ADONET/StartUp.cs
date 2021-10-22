using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace ADONET
{
    class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);

            sqlConnection.Open();
            await using (sqlConnection)
            {
                //2.Villain Names
                //await PrintVillainsWithMoreThan3MinionsAsync(sqlConnection);

                //3.Minion Names
                Console.Write("Enter villain Id: ");
                int villainId = int.Parse(Console.ReadLine());
                await PrintVillainMinionsInfoById(sqlConnection,villainId);
            }
        }


        //2.Villain Names
        private static async Task PrintVillainsWithMoreThan3MinionsAsync(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(Queries.VillainsWithMoreThan3Minions,sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            await using (sqlDataReader)
            {
                while (await sqlDataReader.ReadAsync())
                {
                    string villainName = sqlDataReader.GetString(0);
                    int minionsCount = sqlDataReader.GetInt32(1);

                    Console.WriteLine($"{villainName} - {minionsCount}");
                }
            }
        }

        //3.Minion Names
        private static async Task PrintVillainMinionsInfoById(SqlConnection sqlConnection, int villainId)
        {
            SqlCommand getVillainNameCmd = new SqlCommand(Queries.VillaimsNameById, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);

            object villainNameObject = await getVillainNameCmd.ExecuteScalarAsync();

            if (villainNameObject == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }

            string villainName = (string)villainNameObject;

            SqlCommand villainMinionsInfoCmd = new SqlCommand(Queries.VillainMinionsInfoById,sqlConnection);
            villainMinionsInfoCmd.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader sqlDataReader = await villainMinionsInfoCmd.ExecuteReaderAsync();

            await using (sqlDataReader)
            {
                Console.WriteLine($"Villain: {villainName}");
                if (!sqlDataReader.HasRows)
                {
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    while (await sqlDataReader.ReadAsync())
                    {
                        long rowNumber = sqlDataReader.GetInt64(0);
                        string minionName = sqlDataReader.GetString(1);
                        int minionAge = sqlDataReader.GetInt32(2);

                        Console.WriteLine($"{rowNumber}. {minionName} {minionAge}");
                    }
                }
            }
        }

    }
}
