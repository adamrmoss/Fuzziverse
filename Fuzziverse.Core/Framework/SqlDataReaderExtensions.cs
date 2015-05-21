using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace System.Data.SqlClient
{
  public static class SqlDataReaderExtensions
  {
    public static int? GetNullableInt32(this SqlDataReader reader, int i)
    {
      return reader.IsDBNull(i) ? (int?) null : reader.GetInt32(i);
    }

    public static long? GetNullableInt64(this SqlDataReader reader, int i)
    {
      return reader.IsDBNull(i) ? (long?) null : reader.GetInt64(i);
    }

    public static decimal? GetNullableDecimal(this SqlDataReader reader, int i)
    {
      return reader.IsDBNull(i) ? (decimal?) null : reader.GetDecimal(i);
    }
  }
}
