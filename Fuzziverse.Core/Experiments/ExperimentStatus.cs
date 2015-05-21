using Fuzziverse.Core.AlienSpaceTime;

namespace Fuzziverse.Core.Experiments
{
  public class ExperimentStatus
  {
    public long ExperimentId { get; set; }
    public long? LatestExperimentTurnId { get; set; }
    public AlienDateTime? LatestSimulationTime { get; set; }
    public int? LatestRandomSeed { get; set; }
    public AlienSpaceVector? LatestSunPosition { get; set; }
    public decimal? LatestExtraEnergy { get; set; }
  }
}
