using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Fuzziverse.Core.Experiments;

namespace Fuzziverse.Experiments
{
  public partial class ExperimentView : UserControl, IViewExperiments
  {
    public ExperimentView()
    {
      InitializeComponent();
    }

    public void DisableExperimentTreeView()
    {
      this.experimentsTreeView.Enabled = false;
    }

    public void EnableExperimentTreeView()
    {
      this.experimentsTreeView.Enabled = true;
    }

    public void FocusExperimentTreeView()
    {
      this.experimentsTreeView.Focus();
    }

    public void PopulateExperimentTreeView(IEnumerable<Experiment> experiments)
    {
      this.experimentsTreeView.BeginUpdate();
      this.experimentsTreeView.Nodes.Clear();

      var experimentsByDate = experiments.GroupBy(e => e.Created.Date);

      foreach (var cohort in experimentsByDate) {
        var dateNode = this.experimentsTreeView.Nodes.Add(cohort.Key.ToShortDateString());

        foreach (var experiment in cohort) {
          var key = experiment.Id.ToString(CultureInfo.InvariantCulture);

          var experimentNode = dateNode.Nodes.Add(key, "Experiment #{0}".FormatWith(key));
        }
      }

      this.experimentsTreeView.EndUpdate();

      if (this.experimentsTreeView.Nodes.Count > 0) {
        this.experimentsTreeView.Nodes[0].Expand();
      }
    }

    public long? GetSelectedExperimentId()
    {
      var selectedNode = this.experimentsTreeView.SelectedNode;
      if (selectedNode == null)
        return null;

      long experimentId;
      if (long.TryParse(selectedNode.Name, out experimentId)) {
        return experimentId;
      } else {
        return null;
      }
    }

    public void AddExperimentSelectionChangedHandler(TreeViewEventHandler handler)
    {
      this.experimentsTreeView.AfterSelect += handler;
    }

    public void DisableNewExperimentButton()
    {
      this.newExperimentButton.Enabled = false;
    }

    public void EnableNewExperimentButton()
    {
      this.newExperimentButton.Enabled = true;
    }

    public void AddNewExperimentButtonClickedHandler(EventHandler handler)
    {
      this.newExperimentButton.Click += handler;
    }

    public void DisablePhasesTreeView()
    {
      this.phasesTreeView.Enabled = false;
    }

    public void EnablePhasesTreeView()
    {
      this.phasesTreeView.Enabled = true;
    }

    public void FocusPhasesTreeView()
    {
      this.phasesTreeView.Focus();
    }

    public void PopulatePhasesTreeView(Dictionary<int, List<int>> daysToPhases)
    {
      this.phasesTreeView.BeginUpdate();
      this.phasesTreeView.Nodes.Clear();

      foreach (var kvp in daysToPhases.OrderByDescending(kvp => kvp.Key)) {
        var day = kvp.Key.ToString(CultureInfo.InvariantCulture);
        var dayNode = this.phasesTreeView.Nodes.Add(day, "Day #{0}".FormatWith(day));

        foreach (var phase in kvp.Value.Select(phase => phase.ToString(CultureInfo.InvariantCulture))) {
          var phaseNode = dayNode.Nodes.Add(phase, "Phase #{0}".FormatWith(phase));
        }
      }

      this.phasesTreeView.EndUpdate();
      this.phasesTreeView.ExpandAll();
      this.phasesTreeView.Focus();
    }

    public void AddPhaseSelectionChangedHandler(TreeViewEventHandler handler)
    {
      this.phasesTreeView.AfterSelect += handler;
    }

    public void DisablePlayStopButtons()
    {
      this.playRadioButton.Enabled = false;
      this.stopRadioButton.Enabled = false;
    }

    public void EnablePlayStopButtons()
    {
      this.playRadioButton.Enabled = true;
      this.stopRadioButton.Enabled = true;
    }

    public void AddPlayRadioButtonClickedHandler(EventHandler handler)
    {
      this.playRadioButton.Click += handler;
    }

    public void AddStopRadioButtonClickedHandler(EventHandler handler)
    {
      this.stopRadioButton.Click += handler;
    }
  }
}
