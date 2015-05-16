using System;
using Fuzziverse.Core.AlienTime;

namespace Fuzziverse.Core.Experiments
{
  public class ExperimentTurn
  {
    public long Id { get; set; }
    public long ExperimentId { get; set; }
    public AlienDateTime SimulationTime { get; set; }

    public int SunX { get; set; }
    public int SunY { get; set; }
    public int SunRadius { get; set; }
  }
}
