using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Fuzziverse.Core;
using Fuzziverse.Properties;
using GuardClaws;

namespace Fuzziverse.Databases
{
  public class DatabaseController
  {
    private readonly IViewDatabases databaseSettingsEditor;
    private readonly DatabaseConnector databaseConnector;

    private bool disableChangesToConnection;

    public DatabaseController(IViewDatabases databaseSettingsEditor, DatabaseConnector databaseConnector)
    {
      Claws.NotNull(() => databaseSettingsEditor);
      Claws.NotNull(() => databaseConnector);

      this.databaseSettingsEditor = databaseSettingsEditor;
      this.databaseConnector = databaseConnector;
    }

    public void Initialize()
    {
      this.SubscribeToUserInput();
      this.LoadSettings();
      var autoconnect = this.databaseSettingsEditor.GetAutoconnectCheckBoxValue();
      if (autoconnect) {
        this.PingDatabase();
      }
    }

    private void SubscribeToUserInput()
    {
      this.databaseSettingsEditor.AddSqlInstanceTextBoxChangedHandler(this.OnSqlInstanceTextBoxValueChanged);
      this.databaseSettingsEditor.AddSaveSqlInstanceClickedHandler(this.OnSaveSqlInstanceButtonClicked);
      this.databaseSettingsEditor.AddConnectSqlClickedHandler(this.OnConnectSqlButtonClicked);
      this.databaseSettingsEditor.AddAutoconnectCheckBoxCheckedChangedHandler(this.OnAutoconnectCheckBoxCheckedChanged);
    }

    private void LoadSettings()
    {
      this.databaseSettingsEditor.SetSqlInstanceTextBoxValue(Settings.Default.SqlInstance);
      if (!string.IsNullOrEmpty(Settings.Default.SqlInstance))
        this.databaseConnector.SqlInstance = Settings.Default.SqlInstance;

      if (Settings.Default.Autoconnect) {
        this.databaseSettingsEditor.SetAutoconnectCheckBox();
      } else {
        this.databaseSettingsEditor.ClearAutoconnectCheckBox();
      }
    }

    public void OnSqlInstanceTextBoxValueChanged(object sender, EventArgs eventArgs)
    {
      this.EnableOrDisableComponents();
    }

    public void OnSaveSqlInstanceButtonClicked(object sender, EventArgs eventArgs)
    {
      Settings.Default.SqlInstance = this.databaseSettingsEditor.GetSqlInstanceTextBoxValue();
      Settings.Default.Save();
      this.EnableOrDisableComponents();
    }

    public void OnConnectSqlButtonClicked(object sender, EventArgs eventArgs)
    {
      var sqlInstance = this.databaseSettingsEditor.GetSqlInstanceTextBoxValue();
      this.databaseConnector.SqlInstance = sqlInstance;
      this.PingDatabase();
    }

    private void PingDatabase()
    {
      this.disableChangesToConnection = true;
      this.EnableOrDisableComponents();

      try {
        this.databaseConnector.Ping();
      } catch (Exception e) {
        MessageBox.Show(e.Message, "Ping SQL Server Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.disableChangesToConnection = false;
        this.EnableOrDisableComponents();
      }
    }

    public void OnAutoconnectCheckBoxCheckedChanged(object sender, EventArgs eventArgs)
    {
      Settings.Default.Autoconnect = this.databaseSettingsEditor.GetAutoconnectCheckBoxValue();
      Settings.Default.Save();
    }

    private void EnableOrDisableComponents()
    {
      if (this.disableChangesToConnection) {
        this.databaseSettingsEditor.DisableSqlInstanceTextBox();
        this.databaseSettingsEditor.DisableConnectSqlButton();
        return;
      }

      this.databaseSettingsEditor.EnableSqlInstanceTextBox();
      if (this.databaseSettingsEditor.GetSqlInstanceTextBoxValue() != Settings.Default.SqlInstance) {
        this.databaseSettingsEditor.EnableSaveSqlInstanceButton();
      } else {
        this.databaseSettingsEditor.DisableSaveSqlInstanceButton();
      }

      if (this.databaseSettingsEditor.GetSqlInstanceTextBoxValue() != "") {
        this.databaseSettingsEditor.EnableConnectSqlButton();
      } else {
        this.databaseSettingsEditor.DisableConnectSqlButton();
      }
    }
  }
}
