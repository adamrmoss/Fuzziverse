using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
  }
}
