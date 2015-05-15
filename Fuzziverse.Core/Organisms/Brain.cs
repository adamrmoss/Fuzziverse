namespace Fuzziverse.Core.Organisms
{
  public class Brain
  {
    public long Id { get; set; }

    public long MetabolismNeuronId { get; set; }
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
