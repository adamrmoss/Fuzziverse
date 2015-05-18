using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Fuzziverse.Core.Experiments;
using Fuzziverse.Databases;
using Fuzziverse.Simulations;
using GuardClaws;

namespace Fuzziverse.Experiments
{
  public class ExperimentController
  {
    private readonly IViewExperiments experimentNavigator;
    private readonly ISimulateExperiments experimentSimulator;
    private readonly DatabaseConnector databaseConnector;

    public bool SimulationIsRunning { get; private set; }

    public ExperimentController(IViewExperiments experimentNavigator, ISimulateExperiments experimentSimulator, DatabaseConnector databaseConnector)
    {
      Claws.NotNull(() => experimentNavigator);
      Claws.NotNull(() => experimentSimulator);
      Claws.NotNull(() => databaseConnector);

      this.experimentNavigator = experimentNavigator;
      this.experimentSimulator = experimentSimulator;
      this.databaseConnector = databaseConnector;
    }

    public void Initialize()
    {
      this.experimentNavigator.AddExperimentSelectionChangedHandler(this.OnTreeViewSelectedChanged);
      this.experimentNavigator.AddNewExperimentButtonClickedHandler(this.OnNewSimulationButtonClicked);
      this.experimentNavigator.AddPlayRadioButtonClickedHandler(this.OnPlayRadioButtonClicked);
      this.experimentNavigator.AddStopRadioButtonClickedHandler(this.OnStopRadioButtonClicked);

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
      using (var sqlConnection = this.databaseConnector.OpenSqlConnection()) {
        return sqlConnection.GetAllExperiments();
      }
    }

    private void OnTreeViewSelectedChanged(object sender, TreeViewEventArgs treeViewEventArgs)
    {
      long experimentId;
      if (!long.TryParse(treeViewEventArgs.Node.Name, out experimentId)) {
      this.experimentNavigator.DisablePlayStopButtons();
        return;
      }

      Dictionary<int, List<int>> daysToPhases;
      using (var sqlConnection = this.databaseConnector.OpenSqlConnection()) {
        daysToPhases = sqlConnection.GetExperimentPhases(experimentId);
      }
      this.experimentNavigator.PopulatePhasesTreeView(daysToPhases);
      this.experimentNavigator.EnablePlayStopButtons();
    }

    private void OnNewSimulationButtonClicked(object sender, EventArgs eventArgs)
    {
      using (var sqlConnection = this.databaseConnector.OpenSqlConnection()) {
        var experiment = sqlConnection.CreateExperiment();
      }
      this.LoadExperiments();
    }

    private void OnPlayRadioButtonClicked(object sender, EventArgs eventArgs)
    {
      this.SimulationIsRunning = true;
    }

    private void OnStopRadioButtonClicked(object sender, EventArgs eventArgs)
    {
      this.SimulationIsRunning = false;
    }

    private void EnableOrDisableComponents()
    {
      if (this.databaseConnector.DatabaseHasBeenPinged) {
        this.experimentNavigator.EnableExperimentTreeView();
        this.experimentNavigator.EnableNewExperimentButton();
      } else {
        this.experimentNavigator.DisableExperimentTreeView();
        this.experimentNavigator.DisableNewExperimentButton();
      }

      this.experimentNavigator.DisablePlayStopButtons();
    }
  }
}
