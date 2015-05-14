using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzziverse.Core
{
  public class OrganismState
  {
    public long Id { get; set; }
    public long OrganismId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public decimal Health { get; set; }
    public decimal Damage { get; set; }

    public decimal Metabolism { get; set; }
    public decimal Aggressiveness { get; set; }

    public decimal MoveEast { get; set; }
    public decimal MoveWest { get; set; }
    public decimal MoveNorth { get; set; }
    public decimal MoveSouth { get; set; }

    public decimal Variable1 { get; set; }
    public decimal Variable2 { get; set; }
    public decimal Variable3 { get; set; }
    public decimal Variable4 { get; set; }
  }
}
