using System;
using System.Windows.Forms;
using Fuzziverse.Databases;
using Fuzziverse.Experiments;

namespace Fuzziverse
{
  public partial class ProgramView : Form
  {
    public ProgramView()
    {
      InitializeComponent();
    }

    public DatabaseView DatabaseView { get { return this.databaseView; } }
    public ExperimentView ExperimentView { get { return this.experimentView; } }
  }
}
