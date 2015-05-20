using System;
using System.Windows.Forms;
using Fuzziverse.Databases;
using Fuzziverse.Experiments;
using Fuzziverse.PhaseVisualization;

namespace Fuzziverse
{
  public partial class ProgramView : Form
  {
    public ProgramView()
    {
      InitializeComponent();
    }

    public DatabaseView DatabaseView => this.databaseView;
    public ExperimentView ExperimentView => this.experimentView;
    public PhaseVisualizationView PhaseVisualizationView => this.phaseVisualizationView;

    public void SelectPhaseVisualizationTab()
    {
      this.tabControl.SelectTab("phaseVisualizationTabPage");
    }
  }
}
