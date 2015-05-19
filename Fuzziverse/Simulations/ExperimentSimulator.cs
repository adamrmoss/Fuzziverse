using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Fuzziverse.Core.AlienSpaceTime;
using Fuzziverse.Core.Experiments;
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

        var newExperimentTurn = BuildNextExperimentTurn(experimentStatus);
        sqlConnection.SaveExperimentTurn(newExperimentTurn);
      }
    }

    private static ExperimentTurn BuildNextExperimentTurn(ExperimentStatus experimentStatus)
    {
      var newSimulationTime = experimentStatus.LatestSimulationTime + 1.Turn() ?? new AlienDateTime(0);

      var random = experimentStatus.LatestRandomSeed == null ? new Random() : new Random(experimentStatus.LatestRandomSeed.Value);
      var moveUp = random.Next(4) == 0;

      var newSunPosition = (experimentStatus.LatestSunPosition == null ?
                             new AlienSpaceVector(32, 18) :
                             experimentStatus.LatestSunPosition.Value + new AlienSpaceVector(1, moveUp ? -1 : 0)).ToNonNegativeCoordinates();

      var newSunRadius = experimentStatus.LatestSunRadius ?? 4;

      var newExperimentTurn = new ExperimentTurn {
        ExperimentId = experimentStatus.ExperimentId,
        SimulationTime = newSimulationTime,
        RandomSeed = random.Next(),
        SunPosition = newSunPosition,
        SunRadius = newSunRadius,
      };
      return newExperimentTurn;
    }
  }
}
