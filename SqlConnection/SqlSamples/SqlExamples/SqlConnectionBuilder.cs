using System.Data.SqlClient;


/// <summary>
/// Thsi class use to build and SqlConnection
/// </summary> <summary>
/// 
/// </summary>
public class SqlConnectionBuilder
{
    #region  Variables
    private readonly string _connectionString;
    #endregion

    #region  Constructor
    public SqlConnectionBuilder(string connectionString)
    {
        _connectionString = connectionString;
    }
    #endregion

    #region  

    /// <summary>
    /// This is use to buld SqlClient and open. Where code is used make sure this is in using statement to close connection
    /// </summary>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public SqlConnection Build()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
    #endregion
}
