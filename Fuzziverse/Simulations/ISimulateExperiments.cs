using System.Threading.Tasks;

namespace Fuzziverse.Simulations
{
  public interface ISimulateExperiments
  {
    Task GetTaskToSimulateSingleTurn(long experimentId);
  }
}
