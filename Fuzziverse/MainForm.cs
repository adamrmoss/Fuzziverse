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
  public partial class MainForm : Form, IEditServerSettings
  {
    public MainForm()
    {
      InitializeComponent();
    }

    public void SetSqlInstance(string sqlInstance)
    {
      this.sqlInstanceTextBox.Text = sqlInstance;
    }

    public string GetSqlInstance()
    {
      return this.sqlInstanceTextBox.Text;
    }

    public void AddSqlInstanceChangedHandler(EventHandler handler)
    {
      this.sqlInstanceTextBox.TextChanged += handler;
    }

    public void EnableSaveSqlInstanceButton()
    {
      this.saveSqlInstanceButton.Enabled = true;
    }

    public void DisableSaveSqlInstanceButton()
    {
      this.saveSqlInstanceButton.Enabled = false;
    }

    public void AddSaveSqlInstanceClickedHandler(EventHandler handler)
    {
      this.saveSqlInstanceButton.Click += handler;
    }
  }
}
