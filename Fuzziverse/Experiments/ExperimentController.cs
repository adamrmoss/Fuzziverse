using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fuzziverse.Core.Experiments;
using Fuzziverse.Databases;
using Fuzziverse.Simulations;
using GuardClaws;

namespace Fuzziverse.Experiments
{
  public class ExperimentController
  {
    private readonly IViewExperiments experimentView;
    private readonly DatabaseConnector databaseConnector;
    private readonly ISimulateExperiments experimentSimulator;

    private long? selectedExperimentId;

    public bool SimulationIsRunning { get; private set; }

    public ExperimentController(IViewExperiments experimentView, DatabaseConnector databaseConnector, ISimulateExperiments experimentSimulator)
    {
      Claws.NotNull(() => experimentView);
      Claws.NotNull(() => databaseConnector);
      Claws.NotNull(() => experimentSimulator);

      this.experimentView = experimentView;
      this.databaseConnector = databaseConnector;
      this.experimentSimulator = experimentSimulator;
    }

    public void Initialize()
    {
      this.experimentView.AddExperimentSelectionChangedHandler(this.OnExperimentSelectionChanged);
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

    private void OnExperimentSelectionChanged(object sender, TreeViewEventArgs treeViewEventArgs)
    {
      this.experimentView.ClickStopRadioButton();

      long selectedExperimentId;
      if (!long.TryParse(treeViewEventArgs.Node.Name, out selectedExperimentId)) {
        this.selectedExperimentId = null;
        this.experimentView.DisablePlayStopButtons();
        return;
      }

      this.selectedExperimentId = selectedExperimentId;
      Dictionary<int, List<int>> daysToPhases;
      using (var sqlConnection = this.databaseConnector.OpenSqlConnection()) {
        daysToPhases = sqlConnection.GetExperimentPhases(this.selectedExperimentId.Value);
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
      Task.Factory.StartNew(this.SimulateWhilePossible, "Simulate");
    }

    private void OnStopRadioButtonClicked(object sender, EventArgs eventArgs)
    {
      this.SimulationIsRunning = false;
    }

    private void SimulateWhilePossible(object obj)
    {
      while (true) {
        if (!this.SimulationIsRunning || this.selectedExperimentId == null)
          break;

        this.experimentSimulator.SimulateSingleTurn(this.selectedExperimentId.Value);
      }
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
