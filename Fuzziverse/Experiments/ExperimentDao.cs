using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuzziverse.Core;
using Fuzziverse.Core.Experiments;

namespace Fuzziverse.Experiments
{
  public static class ExperimentDao
  {
    private const string GetAllExperimentsQuery = "SELECT Id, Created FROM dbo.Experiment ORDER BY Created DESC";

    public static List<Experiment> GetAllExperiments(this SqlConnection sqlConnection)
    {
      var sqlCommand = new SqlCommand(GetAllExperimentsQuery, sqlConnection);

      var experiments = new List<Experiment>();
      using (var reader = sqlCommand.ExecuteReader()) {
        if (reader.HasRows)
          while (reader.Read()) {
            experiments.Add(new Experiment {
              Id = reader.GetInt64(0),
              Created = reader.GetDateTime(1),
            });
          }
      }
      return experiments;
    } 
  }
}
