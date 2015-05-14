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

      this.instanceNameTextBox = (TextBox) this.serverTabPage.Controls["instanceNameTextBox"];
    }

    public void Initialize()
    {
      //this.instanceNameTextBox.Text = (string) Properties.Settings.Default["SqlInstance"];
    }
  }
}
