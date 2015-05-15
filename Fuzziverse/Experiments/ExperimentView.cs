using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fuzziverse.Core;

namespace Fuzziverse.Experiments
{
  public partial class ExperimentView : UserControl, INavigateExperiments
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

      foreach (var experiment in experiments) {
        var key = experiment.Id.ToString(CultureInfo.InvariantCulture);
        var text = "({0}) - {1}".FormatWith(experiment.Id, experiment.Created.ToShortDateString());

        var treeNode = this.experimentsTreeView.Nodes.Add(key, text);
      }
      this.experimentsTreeView.EndUpdate();
    }
  }
}
