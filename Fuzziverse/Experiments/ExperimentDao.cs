using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Fuzziverse.Core.Experiments;
using Fuzziverse.Databases;

namespace Fuzziverse.Experiments
{
  public static class ExperimentDao
  {
    private const string getAllExperimentsQuery = "SELECT Id, Created FROM dbo.Experiment ORDER BY Created DESC";
    private const string getExperimentDaysQuery = "SELECT [Day] FROM dbo.GetExperimentDays(@ExperimentId) ORDER BY [Day] DESC";

    public static IEnumerable<Experiment> GetAllExperiments(this SqlConnection sqlConnection)
    {
      var sqlCommand = new SqlCommand(getAllExperimentsQuery, sqlConnection);

      return sqlCommand.ReadResults(reader => new Experiment {
        Id = reader.GetInt64(0),
        Created = reader.GetDateTime(1),
      });
    }

    public static IEnumerable<int> GetExperimentDays(this SqlConnection sqlConnection, long experimentId)
    {
      var sqlCommand = new SqlCommand(getExperimentDaysQuery, sqlConnection);
      var sqlParameter = sqlCommand.Parameters.Add("@ExperimentId", SqlDbType.BigInt);
      sqlParameter.SqlValue = experimentId;

      return sqlCommand.ReadResults(reader => reader.GetInt32(0));
    }
  }
}
