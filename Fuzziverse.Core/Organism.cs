using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzziverse.Core
{
  public class Organism
  {
    public long Id { get; set; }
    public long CurrentStateId { get; set; }

    public decimal Red { get; set; }
    public decimal Green { get; set; }
    public decimal Blue { get; set; }
  }
}
