using System;
using System.Windows.Forms;
using Fuzziverse.Databases;

namespace Fuzziverse
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    public DatabaseView DatabaseView { get { return this.databaseView; } }
  }
}
