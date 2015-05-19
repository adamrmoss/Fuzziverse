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
    private readonly IViewDatabases databaseView;
    private readonly DatabaseConnector databaseConnector;

    private bool disableChangesToConnection;

    public DatabaseController(IViewDatabases databaseView, DatabaseConnector databaseConnector)
    {
      Claws.NotNull(() => databaseView);
      Claws.NotNull(() => databaseConnector);

      this.databaseView = databaseView;
      this.databaseConnector = databaseConnector;
    }

    public void Initialize()
    {
      this.SubscribeToUserInput();
      this.LoadSettings();
      var autoconnect = this.databaseView.GetAutoconnectCheckBoxValue();
      if (autoconnect) {
        this.PingDatabase();
      }
    }

    private void SubscribeToUserInput()
    {
      this.databaseView.AddSqlInstanceTextBoxChangedHandler(this.OnSqlInstanceTextBoxValueChanged);
      this.databaseView.AddSaveSqlInstanceClickedHandler(this.OnSaveSqlInstanceButtonClicked);
      this.databaseView.AddConnectSqlClickedHandler(this.OnConnectSqlButtonClicked);
      this.databaseView.AddAutoconnectCheckBoxCheckedChangedHandler(this.OnAutoconnectCheckBoxCheckedChanged);
    }

    private void LoadSettings()
    {
      this.databaseView.SetSqlInstanceTextBoxValue(Settings.Default.SqlInstance);
      if (!string.IsNullOrEmpty(Settings.Default.SqlInstance))
        this.databaseConnector.SqlInstance = Settings.Default.SqlInstance;

      if (Settings.Default.Autoconnect) {
        this.databaseView.SetAutoconnectCheckBox();
      } else {
        this.databaseView.ClearAutoconnectCheckBox();
      }
    }

    public void OnSqlInstanceTextBoxValueChanged(object sender, EventArgs eventArgs)
    {
      this.EnableOrDisableComponents();
    }

    public void OnSaveSqlInstanceButtonClicked(object sender, EventArgs eventArgs)
    {
      Settings.Default.SqlInstance = this.databaseView.GetSqlInstanceTextBoxValue();
      Settings.Default.Save();
      this.EnableOrDisableComponents();
    }

    public void OnConnectSqlButtonClicked(object sender, EventArgs eventArgs)
    {
      var sqlInstance = this.databaseView.GetSqlInstanceTextBoxValue();
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
      Settings.Default.Autoconnect = this.databaseView.GetAutoconnectCheckBoxValue();
      Settings.Default.Save();
    }

    private void EnableOrDisableComponents()
    {
      if (this.disableChangesToConnection) {
        this.databaseView.DisableSqlInstanceTextBox();
        this.databaseView.DisableConnectSqlButton();
        return;
      }

      this.databaseView.EnableSqlInstanceTextBox();
      if (this.databaseView.GetSqlInstanceTextBoxValue() != Settings.Default.SqlInstance) {
        this.databaseView.EnableSaveSqlInstanceButton();
      } else {
        this.databaseView.DisableSaveSqlInstanceButton();
      }

      if (this.databaseView.GetSqlInstanceTextBoxValue() != "") {
        this.databaseView.EnableConnectSqlButton();
      } else {
        this.databaseView.DisableConnectSqlButton();
      }
    }
  }
}
