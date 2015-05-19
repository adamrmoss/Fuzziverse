using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
  public static class MoreMath
  {
    public static int TrueMod(int x, int m)
    {
      return (x % m + m) % m;
    }
  }
}
