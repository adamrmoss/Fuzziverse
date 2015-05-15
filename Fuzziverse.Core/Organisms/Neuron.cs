namespace Fuzziverse.Core.Organisms
{
  public class Neuron
  {
    public long Id { get; set; }
    public long BrainId { get; set; }

    public decimal HealthFactor { get; set; }
    public decimal DamageFactor { get; set; }

    public decimal MetabolismFactor { get; set; }
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
