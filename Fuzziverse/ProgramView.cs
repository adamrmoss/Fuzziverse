using System;
using System.Windows.Forms;
using Fuzziverse.Databases;

namespace Fuzziverse
{
  public partial class ProgramView : Form
  {
    public ProgramView()
    {
      InitializeComponent();
    }

    public DatabaseView DatabaseView { get { return this.databaseView; } }
  }
}
