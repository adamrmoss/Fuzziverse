using System.Threading.Tasks;
using Fuzziverse.Databases;
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
    }
  }
}
