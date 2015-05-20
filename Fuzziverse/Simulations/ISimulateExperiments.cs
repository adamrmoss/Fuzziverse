using System.Threading.Tasks;

namespace Fuzziverse.Simulations
{
  public interface ISimulateExperiments
  {
    void SimulateSingleTurn(long experimentId);
  }
}
