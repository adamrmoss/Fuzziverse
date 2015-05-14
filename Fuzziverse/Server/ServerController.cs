using System.Windows.Forms;
using Fuzziverse.Properties;

namespace Fuzziverse.Server
{
  public class ServerController
  {
    private readonly IManageServerSettings serverSettingsManager;

    public ServerController(IManageServerSettings serverSettingsManager)
    {
      this.serverSettingsManager = serverSettingsManager;
    }

    public void Initialize()
    {
      this.serverSettingsManager.SetSqlInstance(Settings.Default.SqlInstance);
    }
  }
}
