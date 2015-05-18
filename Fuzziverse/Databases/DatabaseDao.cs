using System.Data.SqlClient;
using System.Linq;

namespace Fuzziverse.Databases
{
  public static class DatabaseDao
  {
    private const string pingQuery = "SELECT Success = dbo.Ping()";

    public static bool Ping(this SqlConnection sqlConnection)
    {
      var sqlCommand = new SqlCommand(pingQuery, sqlConnection);

      return sqlCommand.ReadResults(reader => (bool?) reader.GetBoolean(0)).SingleOrDefault() == true;
    }
  }
}
