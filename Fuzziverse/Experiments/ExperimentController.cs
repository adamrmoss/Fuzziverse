using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Fuzziverse.Core.Experiments;
using Fuzziverse.Databases;

namespace Fuzziverse.Experiments
{
  public class ExperimentController
  {
    private readonly IViewExperiments experimentNavigator;
    private readonly DatabaseController databaseController;

    public ExperimentController(IViewExperiments experimentNavigator, DatabaseController databaseController)
    {
      this.experimentNavigator = experimentNavigator;
      this.databaseController = databaseController;
    }

    public void Initialize()
    {
      this.experimentNavigator.AddExperimentSelectionChangingHandler(this.OnTreeViewSelectedChanging);
      this.experimentNavigator.AddExperimentSelectionChangedHandler(this.OnTreeViewSelectedChanged);
      this.EnableOrDisableComponents();
    }

    public void LoadExperiments()
    {
      this.EnableOrDisableComponents();

      var allExperiments = this.GetExperimentsFromDatabase();
      this.experimentNavigator.PopulateExperimentTreeView(allExperiments);

      this.experimentNavigator.FocusExperimentTreeView();
    }

    private IEnumerable<Experiment> GetExperimentsFromDatabase()
    {
      var connectionString = this.databaseController.GetConnectionString();
      using (var sqlConnection = new SqlConnection(connectionString)) {
        sqlConnection.Open();

        return sqlConnection.GetAllExperiments();
      }
    }

    private void OnTreeViewSelectedChanging(object sender, TreeViewCancelEventArgs treeViewCancelEventArgs)
    {
    }

    private void OnTreeViewSelectedChanged(object sender, TreeViewEventArgs treeViewEventArgs)
    {
      var experimentId = long.Parse(treeViewEventArgs.Node.Name);

      var connectionString = this.databaseController.GetConnectionString();
      Dictionary<int, List<int>> daysToPhases;
      using (var sqlConnection = new SqlConnection(connectionString)) {
        sqlConnection.Open();

        daysToPhases = sqlConnection.GetExperimentPhases(experimentId);
      }
      this.experimentNavigator.PopulatePhaseTreeView(daysToPhases);
    }

    private void EnableOrDisableComponents()
    {
      if (this.databaseController.DatabaseHasBeenPinged) {
        this.experimentNavigator.EnableExperimentTreeView();
      } else {
        this.experimentNavigator.DisableExperimentTreeView();
      }

      this.experimentNavigator.DisablePlayStopButtons();
    }
  }
}
