﻿using System;
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
      this.experimentNavigator.AddNewExperimentButtonClickedHandler(this.OnNewSimulationButtonClicked);

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
      long experimentId;
      if (!long.TryParse(treeViewEventArgs.Node.Name, out experimentId))
        return;

      var connectionString = this.databaseController.GetConnectionString();
      Dictionary<int, List<int>> daysToPhases;
      using (var sqlConnection = new SqlConnection(connectionString)) {
        sqlConnection.Open();

        daysToPhases = sqlConnection.GetExperimentPhases(experimentId);
      }
      this.experimentNavigator.PopulatePhasesTreeView(daysToPhases);
    }

    private void OnNewSimulationButtonClicked(object sender, EventArgs eventArgs)
    {
      var connectionString = this.databaseController.GetConnectionString();
      using (var sqlConnection = new SqlConnection(connectionString)) {
        sqlConnection.Open();

        var experiment = sqlConnection.CreateExperiment();
      }
      this.LoadExperiments();
    }

    private void EnableOrDisableComponents()
    {
      if (this.databaseController.DatabaseHasBeenPinged) {
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
