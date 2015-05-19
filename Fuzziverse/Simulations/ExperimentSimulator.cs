using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Fuzziverse.Core.AlienSpaceTime;
using Fuzziverse.Databases;
using Fuzziverse.Experiments;
using GuardClaws;

namespace Fuzziverse.Simulations
{
  public class ExperimentSimulator : ISimulateExperiments
  {
    private readonly DatabaseConnector databaseConnector;

    public ExperimentSimulator(DatabaseConnector databaseConnector)
    {
      Claws.NotNull(() => databaseConnector);

      this.databaseConnector = databaseConnector;
    }

    public Task GetTaskToSimulateSingleTurn(long experimentId)
    {
      return new Task(() => this.SimulateSingleTurn(experimentId));
    }

    private void SimulateSingleTurn(long experimentId)
    {
      if (!this.databaseConnector.DatabaseHasBeenPinged)
        throw new InvalidOperationException("Cannot run simulation without having pinged the database.");

      using (var sqlConnection = this.databaseConnector.OpenSqlConnection()) {
        var experimentStatus = sqlConnection.GetExperimentStatus(experimentId);

        var newSimulationTime = experimentStatus.LatestSimulationTime + 1.Turn() ?? new AlienDateTime(0);
      }
    }
  }
}
