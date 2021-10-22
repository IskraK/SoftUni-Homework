using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace _04.AddMinion
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string ConnectionString = @"Server=.; Database=MinionsDB; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            await sqlConnection.OpenAsync();

            string[] minionInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTown = minionInfo[3];

            string villainName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

            await using (sqlConnection)
            {
                await AddMinionAsync(sqlConnection, minionName, minionAge, minionTown, villainName);
            }
        }

        private static async Task AddMinionAsync(SqlConnection sqlConnection, string minionName, int minionAge, string minionTown, string villainName)
        {
            SqlCommand getTownIdCmd = new SqlCommand(@"SELECT Id FROM Towns WHERE Name = @townName", sqlConnection);
            getTownIdCmd.Parameters.AddWithValue("@townName", minionTown);

            object townIdObject = await getTownIdCmd.ExecuteScalarAsync();

            if (townIdObject == null)
            {
                SqlCommand insertTownCmd = new SqlCommand(@"INSERT INTO Towns (Name) VALUES (@townName)", sqlConnection);
                insertTownCmd.Parameters.AddWithValue("@townName", minionTown);

                int affectedRowsTown = await insertTownCmd.ExecuteNonQueryAsync();
                if (affectedRowsTown == 0)
                {
                    Console.WriteLine("Problem occured while inserting new town into the database MinionsDB! Please try again later!");
                    return;
                }

                townIdObject = await getTownIdCmd.ExecuteScalarAsync();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }

            int townId = (int)townIdObject;

            SqlCommand getVillainIdCmd = new SqlCommand(@"SELECT Id FROM Villains WHERE Name = @Name", sqlConnection);
            getVillainIdCmd.Parameters.AddWithValue("@Name", villainName);

            object villainIdObject = await getVillainIdCmd.ExecuteScalarAsync();

            if (villainIdObject == null)
            {
                SqlCommand insertVillainCmd = new SqlCommand(@"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)", sqlConnection);
                insertVillainCmd.Parameters.AddWithValue("@villainName", villainName);

                int affectedRowsVillain = await insertVillainCmd.ExecuteNonQueryAsync();

                if (affectedRowsVillain == 0)
                {
                    Console.WriteLine("Problem occured while inserting new villain into the database MinionsDB! Please try again later!");
                    return;
                }

                villainIdObject = await getVillainIdCmd.ExecuteScalarAsync();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            int villainId = (int)villainIdObject;

            SqlCommand insertMinionCmd = new SqlCommand(@"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)", sqlConnection);
            insertMinionCmd.Parameters.AddWithValue("@name", minionName);
            insertMinionCmd.Parameters.AddWithValue("@age", minionAge);
            insertMinionCmd.Parameters.AddWithValue("@townId", townId);

            int affectedRows = await insertMinionCmd.ExecuteNonQueryAsync();

            if (affectedRows == 0)
            {
                Console.WriteLine("Problem occured while inserting new minion into the database MinionsDB! Please try again later!");
                return;
            }

            SqlCommand getMinionIdCmd = new SqlCommand(@"SELECT Id FROM Minions WHERE Name = @Name", sqlConnection);
            getMinionIdCmd.Parameters.AddWithValue("@Name", minionName);

            int minionId = (int)await getMinionIdCmd.ExecuteScalarAsync();

            SqlCommand insertMinionVillainCmd = new SqlCommand(@"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)", sqlConnection);
            insertMinionVillainCmd.Parameters.AddWithValue("@villainId", villainId);
            insertMinionVillainCmd.Parameters.AddWithValue("@minionId", minionId);

            int affectedRowsMV = await insertMinionVillainCmd.ExecuteNonQueryAsync();

            if (affectedRowsMV == 0)
            {
                Console.WriteLine("Problem occured while inserting new minion under the control of the given villain! Please try again later!");
                return;
            }

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }
    }
}
