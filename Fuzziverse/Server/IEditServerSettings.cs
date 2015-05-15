using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzziverse.Server
{
  public interface IEditServerSettings
  {
    void SetSqlInstance(string sqlInstance);
    string GetSqlInstance();

    void AddSqlInstanceChangedHandler(EventHandler handler);

    void EnableSaveSqlInstanceButton();
    void DisableSaveSqlInstanceButton();

    void AddSaveSqlInstanceClickedHandler(EventHandler handler);
  }
}
