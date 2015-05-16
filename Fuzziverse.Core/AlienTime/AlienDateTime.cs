using System;

namespace Fuzziverse.Core.AlienTime
{
  public struct AlienDateTime
  {
    public const int TurnsPerPhase = 64;
    public const int PhasesPerDay = 8;

    public uint Turn { get; set; }
    public uint Phase { get; set; }
    public uint Day { get; set; }

    public uint TotalTurns
    {
      get { return this.Turn + TurnsPerPhase * (this.Phase + PhasesPerDay * this.Day); }
    }

    public static AlienDateTime FromTurns(uint totalTurns)
    {
      var turn = totalTurns % TurnsPerPhase;
      var totalPhases = totalTurns / TurnsPerPhase;
      var phase = totalPhases % PhasesPerDay;
      var day = totalPhases / PhasesPerDay;

      return new AlienDateTime {
        Turn = turn,
        Phase = phase,
        Day = day,
      };
    }

    public static AlienDateTime operator +(AlienTimeSpan alienTimeSpan, AlienDateTime alienDateTime)
    {
      return alienDateTime + alienTimeSpan;
    }

    public static AlienDateTime operator +(AlienDateTime alienDateTime, AlienTimeSpan alienTimeSpan)
    {
      var totalTurns = (uint) (alienDateTime.TotalTurns + alienTimeSpan.Turns);
      return FromTurns(totalTurns);
    }

    public static AlienDateTime operator -(AlienDateTime alienDateTime, AlienTimeSpan alienTimeSpan)
    {
      var totalTurns = (uint) (alienDateTime.TotalTurns - alienTimeSpan.Turns);
      return FromTurns(totalTurns);
    }

    public static AlienTimeSpan operator -(AlienDateTime alienDateTime1, AlienDateTime alienDateTime2)
    {
      return new AlienTimeSpan {Turns = (int) alienDateTime1.TotalTurns - (int) alienDateTime2.TotalTurns};
    }
  }

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
