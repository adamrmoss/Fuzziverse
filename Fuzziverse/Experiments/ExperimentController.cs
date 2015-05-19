using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Fuzziverse.Core.Experiments;
using Fuzziverse.Databases;
using GuardClaws;

namespace Fuzziverse.Experiments
{
  public class ExperimentController
  {
    private readonly IViewExperiments experimentView;
    private readonly DatabaseConnector databaseConnector;

    public bool SimulationIsRunning { get; private set; }

    public ExperimentController(IViewExperiments experimentView, DatabaseConnector databaseConnector)
    {
      Claws.NotNull(() => experimentView);
      Claws.NotNull(() => databaseConnector);

      this.experimentView = experimentView;
      this.databaseConnector = databaseConnector;
    }

    public void Initialize()
    {
      this.experimentView.AddExperimentSelectionChangedHandler(this.OnTreeViewSelectedChanged);
      this.experimentView.AddNewExperimentButtonClickedHandler(this.OnNewSimulationButtonClicked);
      this.experimentView.AddPlayRadioButtonClickedHandler(this.OnPlayRadioButtonClicked);
      this.experimentView.AddStopRadioButtonClickedHandler(this.OnStopRadioButtonClicked);

      this.EnableOrDisableComponents();
    }

    public void LoadExperiments()
    {
      this.EnableOrDisableComponents();

      var allExperiments = this.GetExperimentsFromDatabase();
      this.experimentView.PopulateExperimentTreeView(allExperiments);

      this.experimentView.FocusExperimentTreeView();
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
      this.experimentView.DisablePlayStopButtons();
        return;
      }

      Dictionary<int, List<int>> daysToPhases;
      using (var sqlConnection = this.databaseConnector.OpenSqlConnection()) {
        daysToPhases = sqlConnection.GetExperimentPhases(experimentId);
      }
      this.experimentView.PopulatePhasesTreeView(daysToPhases);
      this.experimentView.EnablePlayStopButtons();
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
        this.experimentView.EnableExperimentTreeView();
        this.experimentView.EnableNewExperimentButton();
      } else {
        this.experimentView.DisableExperimentTreeView();
        this.experimentView.DisableNewExperimentButton();
      }

      this.experimentView.DisablePlayStopButtons();
    }
  }
}
