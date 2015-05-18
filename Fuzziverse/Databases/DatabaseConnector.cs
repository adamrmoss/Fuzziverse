using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzziverse.Databases
{
  public class DatabaseConnector
  {
    private const string connectionStringPattern = "Data Source={0};Initial Catalog=Fuzziverse;Integrated Security=True";

    public string SqlInstance { get; set; }

    public string ConnectionString => this.SqlInstance == null ? null : connectionStringPattern.FormatWith(this.SqlInstance);

    public SqlConnection OpenSqlConnection()
    {
      if (this.ConnectionString == null)
        throw new InvalidOperationException("Cannot Open SqlConnection with null Connection String");
      var sqlConnection = new SqlConnection(this.ConnectionString);
      sqlConnection.Open();
      return sqlConnection;
    }

    public bool DatabaseHasBeenPinged { get; private set; }
    public event Action DatabasePinged;

    public void Ping()
    {
      var sqlConnection = this.OpenSqlConnection();
      var pingSuccess = sqlConnection.Ping();
      if (!pingSuccess) {
        throw new InvalidOperationException("Ping Database returned false, somehow");
      }

      this.DatabaseHasBeenPinged = true;
      this.DatabasePinged?.Invoke();
    }
  }
}
