using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace _06.RemoveVillain
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string ConnectionString = @"Server=.; Database=MinionsDB; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            int villainId = int.Parse(Console.ReadLine());

            using (sqlConnection)
            {
            await sqlConnection.OpenAsync();

                string queryVillainname = @"SELECT Name FROM Villains WHERE Id = @villainId";
                SqlCommand getVillainname = new SqlCommand(queryVillainname, sqlConnection);
                getVillainname.Parameters.AddWithValue("@villainId", villainId);

                object villainNameObject = await getVillainname.ExecuteScalarAsync();

                if (villainNameObject == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                string villainName = (string)villainNameObject;

                string queryDeleteMinionsVillain = @"DELETE FROM MinionsVillains 
                                                     WHERE VillainId = @villainId";
                SqlCommand deleteMinionsVillain = new SqlCommand(queryDeleteMinionsVillain, sqlConnection);
                deleteMinionsVillain.Parameters.AddWithValue("@villainId", villainId);

                int affectedRows = await deleteMinionsVillain.ExecuteNonQueryAsync();
                //affectedRows = released minions

                string queryDeleteVillain = @"DELETE FROM Villains WHERE Id = @villainId";
                SqlCommand deleteVillain = new SqlCommand(queryDeleteVillain, sqlConnection);
                deleteVillain.Parameters.AddWithValue("@villainId", villainId);
                await deleteVillain.ExecuteNonQueryAsync();

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{affectedRows} minions were released.");
            }
        }
    }
}
