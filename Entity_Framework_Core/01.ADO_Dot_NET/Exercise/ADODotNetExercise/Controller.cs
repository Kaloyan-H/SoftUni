using Microsoft.Data.SqlClient;
using System.Text;

public class Controller
{
    //02.Villain Names
    public static async Task<string> GetAllVillainsWithTheirMinionsAsync
        (SqlConnection sqlConnection)
    {
        StringBuilder sb = new StringBuilder();

        SqlCommand sqlCommand = new SqlCommand
            (SqlQueries.GetAllVillainsAndCountOfTheirMinions,
            sqlConnection);

        SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

        while (reader.Read())
        {
            string villainName = (string)reader["Name"];
            int minionsCount = (int)reader["MinionsCount"];

            sb.AppendLine($"{villainName} - {minionsCount}");
        }

        return sb.ToString().TrimEnd();
    }

    //03.Minion Names
    public static async Task<string> GetVillainAndTheirMinionsByVillainIdAsync
        (SqlConnection sqlConnection, int villainId)
    {
        StringBuilder sb = new StringBuilder();

        //SqlParameter villainIdParameter = new SqlParameter("@Id", villainId.ToString());

        SqlCommand getVillainNamesById = new SqlCommand
            (SqlQueries.GetVillainNamesById,
            sqlConnection);
        getVillainNamesById.Parameters.Add(new SqlParameter("@Id", villainId.ToString()));

        SqlCommand getMinionsByVillainId = new SqlCommand
            (SqlQueries.GetMinionsByVillainId,
            sqlConnection);
        getMinionsByVillainId.Parameters.Add(new SqlParameter("@Id", villainId.ToString()));


        string? villainName = (string?)await getVillainNamesById.ExecuteScalarAsync();

        if (villainName != null)
            sb.AppendLine($"Villain: {villainName}");
        else
        {
            sb.AppendLine($"No villain with ID {villainId} exists in the database.");
            return sb.ToString().TrimEnd();
        }

        SqlDataReader reader = await getMinionsByVillainId.ExecuteReaderAsync();

        if (!reader.Read())
        {
            sb.AppendLine("(no minions)");
            return sb.ToString().TrimEnd();
        }
        while (reader.Read())
        {
            string rowNumber = ((long)reader[0]).ToString();
            string minionName = (string)reader[1];
            string minionAge = ((int)reader[2]).ToString();

            sb.AppendLine($"{rowNumber}. {minionName} {minionAge}");
        }

        return sb.ToString().TrimEnd();
    }

    //04.Add Minion
    public static async Task<string> AddMinionToDatabaseAsync
        (SqlConnection sqlConnection,
        string minionName,
        int minionAge,
        string townName,
        string villainName)
    {
        SqlCommand getTownIdByName = new SqlCommand
            (SqlQueries.Get_TownId_ByTownName,
            sqlConnection);
        getTownIdByName.Parameters.Add(new SqlParameter("@townName", townName));

        SqlCommand getVillainIdByName = new SqlCommand
            (SqlQueries.Get_VillainId_ByName,
            sqlConnection);
        getVillainIdByName.Parameters.Add(new SqlParameter("@Name", villainName));

        SqlCommand getMinionIdByName = new SqlCommand
            (SqlQueries.Get_MinionId_ByName,
            sqlConnection);
        getMinionIdByName.Parameters.Add(new SqlParameter("@Name", minionName));

        int? townId = (int?) await getTownIdByName.ExecuteScalarAsync();
        int? villainId = (int?) await getVillainIdByName.ExecuteScalarAsync();
        int? minionId = (int?) await getMinionIdByName.ExecuteScalarAsync();

        if (townId == null)
        {
            Console.WriteLine(await AddTownToDatabaseAsync(sqlConnection, townName));
        }
        if (villainId == null)
        {
            Console.WriteLine(await AddVillainToDatabaseAsync(sqlConnection, villainName));
        }

        SqlCommand addMinionToDatabase = new SqlCommand
            (SqlQueries.INSERT_INTO_Minions,
            sqlConnection);
        addMinionToDatabase.Parameters.Add(new SqlParameter("@name", minionName));
        addMinionToDatabase.Parameters.Add(new SqlParameter("@age", minionAge));
        addMinionToDatabase.Parameters.Add(new SqlParameter("@townId", await getTownIdByName.ExecuteScalarAsync()));

        await addMinionToDatabase.ExecuteNonQueryAsync();

        SqlCommand connectMinionAndVillain = new SqlCommand
            (SqlQueries.INSERT_INTO_MinionsVillains,
            sqlConnection);
        connectMinionAndVillain.Parameters.Add(new SqlParameter("@minionId", await getMinionIdByName.ExecuteScalarAsync()));
        connectMinionAndVillain.Parameters.Add(new SqlParameter("@villainId", await getVillainIdByName.ExecuteReaderAsync()));

        return $"Successfully added {minionName} to be minion of {villainName}.";
    }
    public static async Task<string> AddTownToDatabaseAsync
        (SqlConnection sqlConnection,
        string townName)
    {
        SqlCommand addTownToDatabase = new SqlCommand
            (SqlQueries.INSERT_INTO_Towns,
            sqlConnection);
        addTownToDatabase.Parameters.Add(new SqlParameter("@townName", townName));

        if(await addTownToDatabase.ExecuteNonQueryAsync() == 1)
        {
            return $"Town {townName} was added to the database.";
        }
        else
        {
            throw new Exception($"Town {townName} wasn't added to the database.");
        }
    }
    public static async Task<string> AddVillainToDatabaseAsync
        (SqlConnection sqlConnection,
        string villainName)
    {
        SqlCommand addVillainToDatabase = new SqlCommand
            (SqlQueries.INSERT_INTO_Villains,
            sqlConnection);
        addVillainToDatabase.Parameters.Add(new SqlParameter("@villainName", villainName));

        if (await addVillainToDatabase.ExecuteNonQueryAsync() == 1)
        {
            return $"Villain {villainName} was added to the database.";
        }
        else
        {
            throw new Exception($"Villain {villainName} wasn't added to the database.");
        }
    }
}

