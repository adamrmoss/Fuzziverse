using System;

namespace Fuzziverse.Databases
{
  public interface IEditDatabaseSettings
  {
    void SetSqlInstanceTextBoxValue(string sqlInstance);
    string GetSqlInstanceTextBoxValue();

    void EnableSqlInstanceTextBox();
    void DisableSqlInstanceTextBox();
    void AddSqlInstanceTextBoxChangedHandler(EventHandler handler);

    void EnableSaveSqlInstanceButton();
    void DisableSaveSqlInstanceButton();
    void AddSaveSqlInstanceClickedHandler(EventHandler handler);

    void EnableConnectSqlButton();
    void DisableConnectSqlButton();
    void AddConnectSqlClickedHandler(EventHandler handler);

    void EnableAutoconnectCheckBox();
    void DisableAutoconnectCheckBox();
    void AddAutoconnectCheckBoxClickedHandler(EventHandler handler);
  }
}
