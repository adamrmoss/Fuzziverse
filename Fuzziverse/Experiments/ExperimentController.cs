using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    private void EnableOrDisableComponents()
    {
      var connectionString = this.databaseController.GetConnectionString();
      if (connectionString == null) {
        this.experimentNavigator.DisableTreeView();
      } else {
        this.experimentNavigator.EnableTreeView();
      }
    }
  }
}
