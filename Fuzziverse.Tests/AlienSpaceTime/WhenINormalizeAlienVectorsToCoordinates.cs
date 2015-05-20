using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuzziverse.Core.AlienSpaceTime;
using NUnit.Framework;

namespace Fuzziverse.Tests.AlienSpaceTime
{
  [TestFixture]
  public class WhenINormalizeAlienVectorsToCoordinates : AssertionHelper
  {
    [Test]
    public void It_rolls_over_caty_corner()
    {
      var result = new AlienSpaceVector(-1, -1).ToCoordinates();

      this.Expect(result.X, this.EqualTo(63));
      this.Expect(result.Y, this.EqualTo(35));
    }
  }
}
