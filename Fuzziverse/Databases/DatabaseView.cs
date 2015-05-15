using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuzziverse.Databases
{
  public partial class DatabaseView : UserControl, IEditDatabaseSettings
  {
    public DatabaseView()
    {
      InitializeComponent();
    }

    public void SetSqlInstanceTextBoxValue(string sqlInstance)
    {
      this.sqlInstanceTextBox.Text = sqlInstance;
    }

    public string GetSqlInstanceTextBoxValue()
    {
      return this.sqlInstanceTextBox.Text;
    }

    public void EnableSqlInstanceTextBox()
    {
      this.sqlInstanceTextBox.Enabled = true;
    }

    public void DisableSqlInstanceTextBox()
    {
      this.sqlInstanceTextBox.Enabled = false;
    }

    public void AddSqlInstanceTextBoxChangedHandler(EventHandler handler)
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

    public void EnableConnectSqlButton()
    {
      this.connectSqlButton.Enabled = true;
    }

    public void DisableConnectSqlButton()
    {
      this.connectSqlButton.Enabled = false;
    }

    public void AddConnectSqlClickedHandler(EventHandler handler)
    {
      this.connectSqlButton.Click += handler;
    }

    public void SetAutoconnectCheckBox()
    {
      this.autoconnectCheckBox.Checked = true;
    }

    public void ClearAutoconnectCheckBox()
    {
      this.autoconnectCheckBox.Checked = false;
    }

    public bool GetAutoconnectCheckBoxValue()
    {
      return this.autoconnectCheckBox.Checked;
    }

    public void AddAutoconnectCheckBoxCheckedChangedHandler(EventHandler handler)
    {
      this.autoconnectCheckBox.CheckedChanged += handler;
    }
  }
}
