using System.Data.SqlClient;

namespace SqlExamples;

public class SqlHealthChecker
{
    private readonly string _connectionString;
    public SqlHealthChecker(string connectionString)
    {
        _connectionString = connectionString;
    }
    public bool Health()
    {

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            try
            {
                connection.Open();

                // Perform database operations here

                Console.WriteLine("Connected to the database.");

                // Don't forget to close the connection when done
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        return true;
    }
}
