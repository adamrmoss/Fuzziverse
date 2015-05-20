using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzziverse.Core.AlienSpaceTime
{
  public struct AlienSpaceVector
  {
    public const int WorldWidth = 64;
    public const int WorldHeight = 36;

    public int X { get; }
    public int Y { get; }

    public AlienSpaceVector(int x, int y)
    {
      this.X = x % WorldWidth;
      this.Y = y % WorldHeight;
    }

    public double Abs()
    {
      return Math.Sqrt(this.X * this.X + this.Y * this.Y);
    }

    public AlienSpaceVector ToCoordinates()
    {
      return new AlienSpaceVector(MoreMath.TrueMod(this.X, WorldWidth), MoreMath.TrueMod(this.Y, WorldHeight));
    }

    public static AlienSpaceVector GetCoordinateDelta(AlienSpaceVector vector1, AlienSpaceVector vector2)
    {
      var x2ToX1 = vector1.X - vector2.X;
      var xAround = x2ToX1 - Math.Sign(x2ToX1) * WorldWidth;
      var dx = Math.Abs(x2ToX1) < Math.Abs(xAround) ? x2ToX1 : xAround;

      var y2ToY1 = vector1.Y - vector2.Y;
      var yAround = y2ToY1 - Math.Sign(y2ToY1) * WorldHeight;
      var dy = Math.Abs(y2ToY1) < Math.Abs(yAround) ? y2ToY1 : yAround;

      return new AlienSpaceVector(dx, dy);
    }

    public static AlienSpaceVector operator +(AlienSpaceVector vector1, AlienSpaceVector vector2)
    {
      return new AlienSpaceVector(vector1.X + vector2.X, vector1.Y + vector2.Y);
    }

    public static AlienSpaceVector operator -(AlienSpaceVector vector1, AlienSpaceVector vector2)
    {
      return new AlienSpaceVector(vector1.X - vector2.X, vector1.Y - vector2.Y);
    }

    public override string ToString() => "<{0}, {1}>".FormatWith(this.X, this.Y);
  }
}
