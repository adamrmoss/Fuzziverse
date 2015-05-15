using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Fuzziverse.Core;
using Fuzziverse.Properties;

namespace Fuzziverse.Databases
{
  public class DatabaseController
  {
    private const string connectionStringPattern = "Data Source={0};Initial Catalog=Fuzziverse;Integrated Security=True";

    private readonly IEditDatabaseSettings databaseSettingsEditor;
    public bool DatabaseHasBeenPinged { get; private set; }

    public event Action DatabasePinged;

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
      this.PingDatabase();
    }

    private void PingDatabase()
    {
      this.DatabaseHasBeenPinged = true;
      this.EnableOrDisableComponents();

      try {
        var connectionString = this.GetConnectionString();
        using (var sqlConnection = new SqlConnection(connectionString)) {
          sqlConnection.Open();
          sqlConnection.Ping();
        }

        if (this.DatabasePinged != null) {
          this.DatabasePinged();
        }
      } catch (Exception e) {
        MessageBox.Show(e.Message, "Ping SQL Server Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.DatabaseHasBeenPinged = false;
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
      if (this.DatabaseHasBeenPinged) {
        this.databaseSettingsEditor.DisableSqlInstanceTextBox();
        this.databaseSettingsEditor.DisableSaveSqlInstanceButton();
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
