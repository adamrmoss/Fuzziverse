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
      this.serverSettingsManager.DisableSqlInstanceSave();
    }

    public void OnSqlInstanceChanged(object sender, EventArgs eventArgs)
    {
      this.serverSettingsManager.EnableSqlInstanceSave();
    }
  }
}
