namespace Fuzziverse.Core.Organisms
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
