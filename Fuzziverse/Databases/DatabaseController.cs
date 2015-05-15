using System;
using Fuzziverse.Properties;

namespace Fuzziverse.Databases
{
  public class DatabaseController
  {
    private readonly IEditDatabaseSettings databaseSettingsEditor;
    private bool databaseIsConnected;

    public DatabaseController(IEditDatabaseSettings databaseSettingsEditor)
    {
      this.databaseSettingsEditor = databaseSettingsEditor;
    }

    public void Initialize()
    {
      this.databaseSettingsEditor.AddSqlInstanceTextBoxChangedHandler(this.OnSqlInstanceTextBoxValueChanged);
      this.databaseSettingsEditor.AddSaveSqlInstanceClickedHandler(this.OnSaveSqlInstanceButtonClicked);
      this.databaseSettingsEditor.AddConnectSqlClickedHandler(this.OnConnectSqlButtonClicked);

      this.databaseSettingsEditor.SetSqlInstanceTextBoxValue(Settings.Default.SqlInstance);
    }

    public void OnSqlInstanceTextBoxValueChanged(object sender, EventArgs eventArgs)
    {
      this.EnableOrDisableComponents();
    }

    private void EnableOrDisableComponents()
    {
      if (this.databaseIsConnected) {
        this.databaseSettingsEditor.DisableSqlInstanceTextBox();
        this.databaseSettingsEditor.DisableSaveSqlInstanceButton();
        this.databaseSettingsEditor.DisableConnectSqlButton();
        this.databaseSettingsEditor.DisableAutoconnectCheckBox();
        return;
      }

      if (this.databaseSettingsEditor.GetSqlInstanceTextBoxValue() != Settings.Default.SqlInstance) {
        this.databaseSettingsEditor.EnableSaveSqlInstanceButton();
        this.databaseSettingsEditor.DisableAutoconnectCheckBox();
      } else {
        this.databaseSettingsEditor.DisableSaveSqlInstanceButton();
        this.databaseSettingsEditor.EnableAutoconnectCheckBox();
      }

      if (this.databaseSettingsEditor.GetSqlInstanceTextBoxValue() != "") {
        this.databaseSettingsEditor.EnableConnectSqlButton();
      } else {
        this.databaseSettingsEditor.DisableConnectSqlButton();
      }
    }

    public void OnSaveSqlInstanceButtonClicked(object sender, EventArgs eventArgs)
    {
      Settings.Default.SqlInstance = this.databaseSettingsEditor.GetSqlInstanceTextBoxValue();
      Settings.Default.Save();
      this.EnableOrDisableComponents();
    }

    public void OnConnectSqlButtonClicked(object sender, EventArgs eventArgs)
    {
      this.databaseIsConnected = true;
      this.EnableOrDisableComponents();
    }
  }
}
