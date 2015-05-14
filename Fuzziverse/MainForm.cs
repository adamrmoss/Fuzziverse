using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fuzziverse.Server;

namespace Fuzziverse
{
  public partial class MainForm : Form, IManageServerSettings
  {
    public MainForm()
    {
      InitializeComponent();
    }

    public void SetSqlInstance(string sqlInstance)
    {
      this.sqlInstanceTextBox.Text = sqlInstance;
    }
  }
}
