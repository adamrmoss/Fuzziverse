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
  public class WhenIGetCoordinateDeltas : AssertionHelper
  {
    [Test]
    public void CloseTogether()
    {
      var vector1 = new AlienSpaceVector(5, 5);
      var vector2 = new AlienSpaceVector(7, 3);

      var result1 = AlienSpaceVector.GetCoordinateDelta(vector1, vector2);
      this.Expect(result1.X, this.EqualTo(-2));
      this.Expect(result1.Y, this.EqualTo(2));

      var result2 = AlienSpaceVector.GetCoordinateDelta(vector2, vector1);
      this.Expect(result2.X, this.EqualTo(2));
      this.Expect(result2.Y, this.EqualTo(-2));
    }

    [Test]
    public void CatyCorner()
    {
      var vector1 = new AlienSpaceVector(0, 0);
      var vector2 = new AlienSpaceVector(63, 35);

      var result1 = AlienSpaceVector.GetCoordinateDelta(vector1, vector2);
      this.Expect(result1.X, this.EqualTo(1));
      this.Expect(result1.Y, this.EqualTo(1));

      var result2 = AlienSpaceVector.GetCoordinateDelta(vector2, vector1);
      this.Expect(result2.X, this.EqualTo(-1));
      this.Expect(result2.Y, this.EqualTo(-1));
    }
  }
}
