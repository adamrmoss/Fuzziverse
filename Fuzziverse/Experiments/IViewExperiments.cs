using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fuzziverse.Core;
using Fuzziverse.Core.Experiments;

namespace Fuzziverse.Experiments
{
  public interface IViewExperiments
  {
    void DisableTreeView();
    void EnableTreeView();
    void FocusTreeView();
    void PopulateTreeView(IEnumerable<Experiment> experiments);
    long? GetSelectedExperimentId();
    void AddTreeViewSelectionChangedHandler(TreeViewEventHandler handler);

    void DisablePlayStopButtons();
    void EnablePlayStopButtons();
  }
}
