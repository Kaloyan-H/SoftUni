
public static class SqlQueries
{
    //02.Villain Names
    public const string GetAllVillainsAndCountOfTheirMinions =
        @"    SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                FROM Villains AS v 
                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
            GROUP BY v.Id, v.Name 
              HAVING COUNT(mv.VillainId) > 3 
            ORDER BY COUNT(mv.VillainId)";

    //03.Minion Names
    public const string GetVillainNamesById =
        @"SELECT Name FROM Villains WHERE Id = @Id";

    public const string GetMinionsByVillainId =
        @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

    //04.Add Minion
    public const string Get_VillainId_ByName =
        @"SELECT Id FROM Villains WHERE Name = @Name";

    public const string Get_MinionId_ByName =
        @"SELECT Id FROM Minions WHERE Name = @Name";

    public const string Get_TownId_ByTownName =
        @"SELECT Id FROM Towns WHERE Name = @townName";

    public const string INSERT_INTO_MinionsVillains =
        @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

    public const string INSERT_INTO_Villains =
        @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

    public const string INSERT_INTO_Minions =
        @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
    public const string INSERT_INTO_Towns =
        @"INSERT INTO Towns (Name) VALUES (@townName)";


}

