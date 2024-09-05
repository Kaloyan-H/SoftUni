using Microsoft.Data.SqlClient;

await using SqlConnection dbConnection =
    new SqlConnection(Config.CONNECTION_STRING);

await dbConnection.OpenAsync();

//02.VILLAIN NAMES
//string result = await Controller.GetAllVillainsWithTheirMinionsAsync(dbConnection);
//Console.WriteLine(result);

//03.MINION NAMES
//int villainId = int.Parse(Console.ReadLine());

//string result = await Controller
//    .GetVillainAndTheirMinionsByVillainIdAsync(dbConnection, villainId);
//Console.WriteLine(result);

//04.ADD MINION
string[] minionInfo = Console.ReadLine()
    .Substring(7)
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

string villainName = Console.ReadLine()
    .Substring(8)
    .Trim();

string minionName = minionInfo[0];
int minionAge = int.Parse(minionInfo[1]);
string townName = minionInfo[2];

string result = await Controller
    .AddMinionToDatabaseAsync
    (dbConnection,
    minionName,
    minionAge,
    townName,
    villainName);

Console.WriteLine(result);


