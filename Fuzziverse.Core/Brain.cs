using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzziverse.Core
{
  public class Brain
  {
    public long Id { get; set; }

    public long IntensityNeuronId { get; set; }
    public long AggressivenessNeuronId { get; set; }

    public long MoveEastNeuronId { get; set; }
    public long MoveWestNeuronId { get; set; }
    public long MoveNorthNeuronId { get; set; }
    public long MoveSouthNeuronId { get; set; }

    public long Variable1NeuronId { get; set; }
    public long Variable2NeuronId { get; set; }
    public long Variable3NeuronId { get; set; }
    public long Variable4NeuronId { get; set; }
  }
}
