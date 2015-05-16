namespace Fuzziverse.Core.AlienTime
{
  public struct AlienTimeSpan
  {
    public int Turns { get; set; }

    public static AlienTimeSpan operator +(AlienTimeSpan alienTimeSpan1, AlienTimeSpan alienTimeSpan2)
    {
      return new AlienTimeSpan {Turns = alienTimeSpan1.Turns + alienTimeSpan2.Turns};
    }

    public static AlienTimeSpan operator -(AlienTimeSpan alienTimeSpan1, AlienTimeSpan alienTimeSpan2)
    {
      return new AlienTimeSpan {Turns = alienTimeSpan1.Turns - alienTimeSpan2.Turns};
    }
  }
}
