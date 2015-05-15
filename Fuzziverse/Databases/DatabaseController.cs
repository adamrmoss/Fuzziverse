using System;
using System.Data.SqlClient;
using Fuzziverse.Core;
using Fuzziverse.Experiments;
using Fuzziverse.Properties;

namespace Fuzziverse.Databases
{
  public class DatabaseController
  {
    private const string connectionStringPattern = "Data Source={0};Initial Catalog=Fuzziverse;Integrated Security=True";

    private readonly IEditDatabaseSettings databaseSettingsEditor;
    private bool databaseIsConnected;

    public DatabaseController(IEditDatabaseSettings databaseSettingsEditor)
    {
      this.databaseSettingsEditor = databaseSettingsEditor;
    }

    public string GetConnectionString()
    {
      var sqlInstance = this.databaseSettingsEditor.GetSqlInstanceTextBoxValue();
      return sqlInstance == "" ? null : connectionStringPattern.FormatWith(sqlInstance);
    }

    public void Initialize()
    {
      this.SubscribeToUserInput();
      this.LoadSettings();
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
      this.databaseIsConnected = true;
      this.EnableOrDisableComponents();

      var connectionString = GetConnectionString();
      using (var sqlConnection = new SqlConnection(connectionString)) {
        sqlConnection.Open();
        var allExperiments = sqlConnection.GetAllExperiments();
      }
    }

    public void OnAutoconnectCheckBoxCheckedChanged(object sender, EventArgs eventArgs)
    {
      Settings.Default.Autoconnect = this.databaseSettingsEditor.GetAutoconnectCheckBoxValue();
      Settings.Default.Save();
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
  }
}
