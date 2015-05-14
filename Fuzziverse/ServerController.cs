using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuzziverse
{
  public class ServerController
  {
    private readonly TabPage serverTabPage;
    private readonly TextBox instanceNameTextBox;

    public ServerController(TabPage serverTabPage)
    {
      this.serverTabPage = serverTabPage;

      this.instanceNameTextBox = (TextBox) this.serverTabPage.Controls["databaseGroupBox"].Controls["instanceNameTextBox"];
    }

    public void Initialize()
    {
      this.instanceNameTextBox.Text = Properties.Settings.Default.SqlInstance;
    }
  }
}
