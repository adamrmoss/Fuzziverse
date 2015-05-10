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
    public Genome Genome { get; private set; }

    public Organism(Genome genome)
    {
      Genome = genome;
    }
  }
}
