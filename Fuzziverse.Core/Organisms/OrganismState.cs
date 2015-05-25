﻿using Fuzziverse.Core.AlienSpaceTime;

namespace Fuzziverse.Core.Organisms
{
  public class OrganismState
  {
    public long Id { get; set; }
    public long OrganismId { get; set; }
    public long ExperimentTurnId { get; set; }

    public AlienSpaceVector Position { get; set; }

    public decimal Health { get; set; }
  }
}
