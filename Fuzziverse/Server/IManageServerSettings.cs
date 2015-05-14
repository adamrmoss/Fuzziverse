using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzziverse.Server
{
  public interface IManageServerSettings
  {
    void SetSqlInstance(string sqlInstance);
  }
}
