using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuzziverse.Core.AlienTime;
using NUnit.Framework;

namespace Fuzziverse.Tests.AlienTime
{
  [TestFixture]
  public class WhenICompareAlienTimes : AssertionHelper
  {
    [Test]
    public void WhenThereIsAPositiveDifference()
    {
      var alienTime1 = new AlienDateTime {
        Day = 0,
        Phase = 1,
        Turn = 39,
      };

      var alienTime2 = new AlienDateTime {
        Day = 0,
        Phase = 0,
        Turn = 5,
      };

      var alienTimeSpan = alienTime1 - alienTime2;
      Expect(alienTimeSpan.Turns, this.EqualTo(162));
    }

    [Test]
    public void WhenThereIsANegativeDifference()
    {
      var alienTime1 = new AlienDateTime {
        Day = 0,
        Phase = 1,
        Turn = 39,
      };

      var alienTime2 = new AlienDateTime {
        Day = 1,
        Phase = 0,
        Turn = 0,
      };

      var alienTimeSpan = alienTime1 - alienTime2;
      Expect(alienTimeSpan.Turns, this.EqualTo(-857));
    }
  }
}
