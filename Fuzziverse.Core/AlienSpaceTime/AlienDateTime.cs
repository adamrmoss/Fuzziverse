using System;

namespace Fuzziverse.Core.AlienSpaceTime
{
  public struct AlienDateTime
  {
    public const int TurnsPerPhase = 128;
    public const int PhasesPerDay = 8;

    public int TotalTurns { get; set; }

    public int Turn => this.TotalTurns % TurnsPerPhase;
    public int Phase => (this.TotalTurns / TurnsPerPhase) % PhasesPerDay;
    public int Day => (this.TotalTurns / TurnsPerPhase / PhasesPerDay);

    public AlienDateTime(int day, int phase, int turn)
      :this(turn + TurnsPerPhase * (phase + PhasesPerDay * day))
    {
    }

    public AlienDateTime(int totalTurns)
    {
      this.TotalTurns = totalTurns;
    }

    public static AlienDateTime operator +(AlienTimeSpan alienTimeSpan, AlienDateTime alienDateTime)
    {
      return alienDateTime + alienTimeSpan;
    }

    public static AlienDateTime operator +(AlienDateTime alienDateTime, AlienTimeSpan alienTimeSpan)
    {
      var totalTurns = alienDateTime.TotalTurns + alienTimeSpan.Turns;
      return new AlienDateTime(totalTurns);
    }

    public static AlienDateTime operator -(AlienDateTime alienDateTime, AlienTimeSpan alienTimeSpan)
    {
      var totalTurns = alienDateTime.TotalTurns - alienTimeSpan.Turns;
      return new AlienDateTime(totalTurns);
    }

    public static AlienTimeSpan operator -(AlienDateTime alienDateTime1, AlienDateTime alienDateTime2)
    {
      return new AlienTimeSpan(alienDateTime1.TotalTurns - alienDateTime2.TotalTurns);
    }

    public override string ToString() => "{0}:{1}:{2}".FormatWith(this.Day, this.Phase, this.Turn);
  }
}
