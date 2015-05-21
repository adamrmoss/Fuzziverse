namespace Fuzziverse.Core.Organisms
{
  public class OrganismState
  {
    public long Id { get; set; }
    public long OrganismId { get; set; }
    public long ExperimentTurnId { get; set; }

    public int X { get; set; }
    public int Y { get; set; }

    public decimal Health { get; set; }
  }
}
