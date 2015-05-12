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
    public decimal Energy { get; set; }
  }
}
