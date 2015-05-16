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
      this.experimentNavigator.AddTreeViewSelectionChangingHandler(this.OnTreeViewSelectedChanging);
      this.experimentNavigator.AddTreeViewSelectionChangedHandler(this.OnTreeViewSelectedChanged);
      this.EnableOrDisableComponents();
    }

    public void LoadExperiments()
    {
      this.EnableOrDisableComponents();

      var allExperiments = this.GetExperimentsFromDatabase();
      this.experimentNavigator.PopulateTreeView(allExperiments);

      this.experimentNavigator.FocusTreeView();
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
      treeViewCancelEventArgs.Node.Nodes.Clear();
    }

    private void OnTreeViewSelectedChanged(object sender, TreeViewEventArgs treeViewEventArgs)
    {
      treeViewEventArgs.Node.Nodes.Clear();
      var experimentId = long.Parse(treeViewEventArgs.Node.Name);

      var connectionString = this.databaseController.GetConnectionString();
      int[] days;
      using (var sqlConnection = new SqlConnection(connectionString)) {
        sqlConnection.Open();

        days = sqlConnection.GetExperimentDays(experimentId).ToArray();
      }
      foreach (var day in days) {
        var dayNode = treeViewEventArgs.Node.Nodes.Add(day.ToString(CultureInfo.InvariantCulture));
      }
      treeViewEventArgs.Node.Expand();
    }

    private void EnableOrDisableComponents()
    {
      if (this.databaseController.DatabaseHasBeenPinged) {
        this.experimentNavigator.EnableTreeView();
      } else {
        this.experimentNavigator.DisableTreeView();
      }

      this.experimentNavigator.DisablePlayStopButtons();
    }
  }
}
