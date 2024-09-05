using Microsoft.Data.SqlClient;

SqlConnection dbConnection = new SqlConnection
    (
        "Server = localhost;" +
        "Database = SoftUni;" +
        "User Id = sa;" +
        "Password = sa;" +
        "Trust Server Certificate = true"
    );

dbConnection.Open();

using (dbConnection)
{
    SqlCommand command = new SqlCommand
        (
            "SELECT COUNT(*)" +
            "FROM Employees",
            dbConnection
        );

    int employeeCount = (int)command.ExecuteScalar();

    Console.WriteLine($"There are {employeeCount} employees in our company;");
}
