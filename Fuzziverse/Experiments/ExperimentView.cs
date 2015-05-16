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

    public void DisableTreeView()
    {
      this.experimentsTreeView.Enabled = false;
    }

    public void EnableTreeView()
    {
      this.experimentsTreeView.Enabled = true;
    }

    public void FocusTreeView()
    {
      this.experimentsTreeView.Focus();
    }

    public void PopulateTreeView(IEnumerable<Experiment> experiments)
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

      this.experimentsTreeView.Nodes[0].Expand();
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

    public void AddTreeViewSelectionChangingHandler(TreeViewCancelEventHandler handler)
    {
      this.experimentsTreeView.BeforeSelect += handler;
    }

    public void AddTreeViewSelectionChangedHandler(TreeViewEventHandler handler)
    {
      this.experimentsTreeView.AfterSelect += handler;
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
  }
}
