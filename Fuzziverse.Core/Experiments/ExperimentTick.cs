using System;

namespace Fuzziverse.Core.Experiments
{
  public class ExperimentTick
  {
    public long Id { get; set; }
    public long ExperimentId { get; set; }
    public DateTime SimulationTime { get; set; }
  }
}
