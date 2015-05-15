using System;
using System.Windows.Forms;
using Fuzziverse.Properties;

namespace Fuzziverse.Server
{
  public class ServerController
  {
    private readonly IEditServerSettings serverSettingsManager;

    public ServerController(IEditServerSettings serverSettingsManager)
    {
      this.serverSettingsManager = serverSettingsManager;
    }

    public void Initialize()
    {
      this.serverSettingsManager.SetSqlInstance(Settings.Default.SqlInstance);

      this.serverSettingsManager.AddSqlInstanceChangedHandler(this.OnSqlInstanceChanged);
      this.serverSettingsManager.AddSaveSqlInstanceClickedHandler(this.OnSaveSqlInstanceButtonClicked);

      this.serverSettingsManager.DisableSaveSqlInstanceButton();
    }

    public void OnSqlInstanceChanged(object sender, EventArgs eventArgs)
    {
      this.serverSettingsManager.EnableSaveSqlInstanceButton();
    }

    public void OnSaveSqlInstanceButtonClicked(object sender, EventArgs eventArgs)
    {
      Settings.Default.SqlInstance = this.serverSettingsManager.GetSqlInstance();
      Settings.Default.Save();
      this.serverSettingsManager.DisableSaveSqlInstanceButton();
    }
  }
}
