namespace Fuzziverse.Core.AlienSpaceTime
{
  public struct AlienTimeSpan
  {
    public int Turns { get; }

    public AlienTimeSpan(int turns)
    {
      this.Turns = turns;
    }

    public static AlienTimeSpan operator +(AlienTimeSpan alienTimeSpan1, AlienTimeSpan alienTimeSpan2)
    {
      return new AlienTimeSpan(alienTimeSpan1.Turns + alienTimeSpan2.Turns);
    }

    public static AlienTimeSpan operator -(AlienTimeSpan alienTimeSpan1, AlienTimeSpan alienTimeSpan2)
    {
      return new AlienTimeSpan(alienTimeSpan1.Turns - alienTimeSpan2.Turns);
    }
  }

  public static class IntegerExtensionsForAlienTimeSpan
  {
    public static AlienTimeSpan Turn(this int totalTurns)
    {
      return Turns(totalTurns);
    }

    public static AlienTimeSpan Turns(this int totalTurns)
    {
      return new AlienTimeSpan(totalTurns);
    }
  }
}
