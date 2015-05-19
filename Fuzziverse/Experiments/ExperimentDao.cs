using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using Fuzziverse.Core.AlienSpaceTime;
using Fuzziverse.Core.Experiments;
using Fuzziverse.Databases;

namespace Fuzziverse.Experiments
{
  public static class ExperimentDao
  {
    private const string getAllExperimentsQuery = "SELECT Id, Created FROM dbo.Experiment ORDER BY Created DESC";
    private const string createExperimentCommand = "EXEC dbo.CreateExperiment";
    private const string getExperimentDaysQuery = "SELECT [Day], Phase FROM dbo.GetExperimentPhases(@ExperimentId) ORDER BY [Day] DESC";
    private const string getExperimentStatusQuery = "SELECT LatestExperimentTurnId, LatestSimulationTime, LatestSunX, LatestSunY, LatestSunRadius FROM dbo.GetExperimentStatus(@ExperimentId)";

    public static Experiment CreateExperiment(this SqlConnection sqlConnection)
    {
      var sqlCommand = new SqlCommand(createExperimentCommand, sqlConnection);

      return sqlCommand.ReadResults(ReadExperimentRow).SingleOrDefault();
    }

    public static IEnumerable<Experiment> GetAllExperiments(this SqlConnection sqlConnection)
    {
      var sqlCommand = new SqlCommand(getAllExperimentsQuery, sqlConnection);

      return sqlCommand.ReadResults(ReadExperimentRow);
    }

    private static Experiment ReadExperimentRow(SqlDataReader reader)
    {
      return new Experiment {
        Id = reader.GetInt64(0),
        Created = reader.GetDateTime(1),
      };
    }

    public static Dictionary<int, List<int>> GetExperimentPhases(this SqlConnection sqlConnection, long experimentId)
    {
      var sqlCommand = new SqlCommand(getExperimentDaysQuery, sqlConnection);
      var sqlParameter = sqlCommand.Parameters.Add("@ExperimentId", SqlDbType.BigInt);
      sqlParameter.SqlValue = experimentId;

      var results = sqlCommand.ReadResults(reader => new { Day = reader.GetInt32(0), Phase = reader.GetInt32(1)});
      return results.GroupBy(result => result.Day)
        .ToDictionary(g => g.Key, g => g.Select(result => result.Phase).ToList());
    }

    public static ExperimentStatus GetExperimentStatus(this SqlConnection sqlConnection, long experimentId)
    {
      var sqlCommand = new SqlCommand(getExperimentStatusQuery, sqlConnection);
      var sqlParameter = sqlCommand.Parameters.Add("@ExperimentId", SqlDbType.BigInt);
      sqlParameter.SqlValue = experimentId;

      return sqlCommand.ReadResults(reader => ReadExperimentStatus(reader, experimentId)).Single();
    }

    private static ExperimentStatus ReadExperimentStatus(SqlDataReader reader, long experimentId)
    {
      return new ExperimentStatus {
        ExperimentId = experimentId,
        LatestExperimentTurnId = reader.GetNullableInt64(0),
        LatestSimulationTime = reader.IsDBNull(1) ? (AlienDateTime?) null : new AlienDateTime(reader.GetInt32(1)),
        LatestRandomSeed = reader.GetNullableInt32(2),
        LatestSunX = reader.GetNullableInt32(3),
        LatestSunY = reader.GetNullableInt32(4),
        LatestSunRadius = reader.GetNullableInt32(5),
      };
    }
  }
}
