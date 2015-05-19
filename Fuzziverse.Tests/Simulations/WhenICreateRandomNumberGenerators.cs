using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Fuzziverse.Tests.Simulations
{
  [TestFixture]
  public class WhenICreateRandomNumberGenerators : AssertionHelper
  {
    [Test]
    public void WhenISeedOneGeneratorFromAnother()
    {
      var random1 = new Random();
      var generatedNumber = random1.Next();

      var random2 = new Random(generatedNumber);
      var next1 = random1.Next();
      var next2 = random2.Next();
      this.Expect(next1 == next2);
    }
  }
}
