﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzziverse.Databases
{
  public static class SqlCommandExtensions
  {
    public static IEnumerable<TReaderResult> ReadResults<TReaderResult>(this SqlCommand sqlCommand, Func<SqlDataReader, TReaderResult> recordProcessor)
    {
      var results = new List<TReaderResult>();
      using (var reader = sqlCommand.ExecuteReader()) {
        if (reader.HasRows)
          while (reader.Read()) {
            results.Add(recordProcessor(reader));
          }
      }
      return results;
    }
  }
}
