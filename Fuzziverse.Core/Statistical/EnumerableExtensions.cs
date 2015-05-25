using System;
using System.Collections.Generic;
using System.Linq;

namespace Fuzziverse.Core.Statistical
{
  public static class EnumerableExtensions
  {
    public static T GetRandomElement<T>(this IEnumerable<T> sequence, Random random)
    {
      var sequenceAsArray = sequence as T[] ?? sequence.ToArray();
      var index = random.Next(sequenceAsArray.Length);

      return sequenceAsArray[index];
    }

    public static IEnumerable<T> Randomize<T>(this IEnumerable<T> sequence, Random random)
    {
      var sequenceAsArray = sequence as T[] ?? sequence.ToArray();
      var elements = new HashSet<T>(sequenceAsArray);

      while (elements.Count > 0) {
        var randomElement = sequenceAsArray.GetRandomElement(random);
        if (elements.Contains(randomElement)) {
          elements.Remove(randomElement);
          yield return randomElement;
        }
      }
    }
  }
}
