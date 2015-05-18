using System.Threading.Tasks;

namespace Fuzziverse.Simulations
{
  public class ExperimentSimulator : ISimulateExperiments
  {
    public Task GetTaskToSimulateSingleTurn(long experimentId)
    {
      return new Task(() => this.SimulateSingleTurn(experimentId));
    }

    private void SimulateSingleTurn(long experimentId)
    {
    }
  }
}
