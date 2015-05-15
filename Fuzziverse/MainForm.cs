using System;
using System.Windows.Forms;
using Fuzziverse.Databases;

namespace Fuzziverse
{
  public partial class MainForm : Form, IEditDatabaseSettings
  {
    public MainForm()
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

    public void EnableAutoconnectCheckBox()
    {
      this.autoconnectCheckBox.Enabled = true;
    }

    public void DisableAutoconnectCheckBox()
    {
      this.autoconnectCheckBox.Enabled = false;
    }

    public void AddAutoconnectCheckBoxClickedHandler(EventHandler handler)
    {
      this.autoconnectCheckBox.Click += handler;
    }
  }
}
