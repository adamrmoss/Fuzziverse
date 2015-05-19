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

    public AlienSpaceVector ToNonNegativeCoordinates()
    {
      return new AlienSpaceVector(MoreMath.TrueMod(this.X, WorldWidth), MoreMath.TrueMod(this.Y, WorldHeight));
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
