using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public int? LatestSunRadius { get; set; }
  }
}
