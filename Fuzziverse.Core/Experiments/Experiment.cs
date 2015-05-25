using System;

namespace Fuzziverse.Core.Experiments
{
  public class Experiment
  {
    public const int SunRadius = 10;
    public const decimal SunEnergyGift = 1m;
    public const decimal HungerRate = 0.25m;

    public const decimal Richness = 0.2m;
    public const int MaxBirthRate = 16;

    public long Id { get; set; }
    public DateTime Created { get; set; }
  }
}
