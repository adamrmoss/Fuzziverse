using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fuzziverse.Core;
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

    private void OnTreeViewSelectedChanged(object sender, TreeViewEventArgs treeViewEventArgs)
    {
      var experimentId = long.Parse(treeViewEventArgs.Node.Name);
      //MessageBox.Show(experimentId);
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
