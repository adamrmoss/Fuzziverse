using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzziverse.Core
{
  public class Neuron
  {
    public long Id { get; set; }
    public long BrainId { get; set; }

    public decimal HealthFactor { get; set; }
    public decimal DamageFactor { get; set; }

    public decimal IntensityFactor { get; set; }
    public decimal AggressivenessFactor { get; set; }

    public decimal MoveEastFactor { get; set; }
    public decimal MoveWestFactor { get; set; }
    public decimal MoveNorthFactor { get; set; }
    public decimal MoveSouthFactor { get; set; }

    public decimal Variable1Factor { get; set; }
    public decimal Variable2Factor { get; set; }
    public decimal Variable3Factor { get; set; }
    public decimal Variable4Factor { get; set; }
  }
}
