using System.Data.SqlClient;

namespace Fuzziverse.Databases
{
  public static class DatabaseDao
  {
    private const string PingQuery = "SELECT Success = dbo.Ping()";

    public static bool Ping(this SqlConnection sqlConnection)
    {
      var sqlCommand = new SqlCommand(PingQuery, sqlConnection);

      using (var reader = sqlCommand.ExecuteReader()) {
        while (reader.HasRows && reader.Read()) {
          return reader.GetBoolean(0);
        }

        return false;
      }
    }
  }
}
