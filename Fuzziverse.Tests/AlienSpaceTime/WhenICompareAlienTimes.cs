using Fuzziverse.Core.AlienSpaceTime;
using NUnit.Framework;

namespace Fuzziverse.Tests.AlienSpaceTime
{
  [TestFixture]
  public class WhenICompareAlienTimes : AssertionHelper
  {
    [Test]
    public void WhenThereIsAPositiveDifference()
    {
      var alienTime1 = new AlienDateTime(0, 1, 39);
      var alienTime2 = new AlienDateTime(0, 0, 5);

      var alienTimeSpan = alienTime1 - alienTime2;
      this.Expect(alienTimeSpan.Turns, this.EqualTo(162));
    }

    [Test]
    public void WhenThereIsANegativeDifference()
    {
      var alienTime1 = new AlienDateTime(0, 1, 39);
      var alienTime2 = new AlienDateTime(1, 0, 0);

      var alienTimeSpan = alienTime1 - alienTime2;
      this.Expect(alienTimeSpan.Turns, this.EqualTo(-857));
    }
  }
}
