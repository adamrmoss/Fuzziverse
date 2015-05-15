using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzziverse.Core
{
  public class ExperimentTick
  {
    public long Id { get; set; }
    public long ExperimentId { get; set; }
    public DateTime SimulationTime { get; set; }
  }
}
