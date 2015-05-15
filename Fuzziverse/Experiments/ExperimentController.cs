using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuzziverse.Core;
using Fuzziverse.Core.Experiments;
using Fuzziverse.Databases;

namespace Fuzziverse.Experiments
{
  public class ExperimentController
  {
    private readonly INavigateExperiments experimentNavigator;
    private readonly DatabaseController databaseController;

    public ExperimentController(INavigateExperiments experimentNavigator, DatabaseController databaseController)
    {
      this.experimentNavigator = experimentNavigator;
      this.databaseController = databaseController;
    }

    public void Initialize()
    {
      this.EnableOrDisableComponents();
    }

    public void LoadExperiments()
    {
      this.EnableOrDisableComponents();

      var allExperiments = this.GetExperimentsFromDatabase();
      this.experimentNavigator.PopulateTreeView(allExperiments);

      this.experimentNavigator.FocusTreeView();
    }

    private List<Experiment> GetExperimentsFromDatabase()
    {
      var connectionString = this.databaseController.GetConnectionString();
      using (var sqlConnection = new SqlConnection(connectionString)) {
        sqlConnection.Open();

        return sqlConnection.GetAllExperiments();
      }
    }

    private void EnableOrDisableComponents()
    {
      if (this.databaseController.DatabaseHasBeenPinged) {
        this.experimentNavigator.EnableTreeView();
      } else {
        this.experimentNavigator.DisableTreeView();
      }
    }
  }
}
