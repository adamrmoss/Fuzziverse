using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuzziverse.Core;
using Fuzziverse.Core.Experiments;

namespace Fuzziverse.Experiments
{
  public interface INavigateExperiments
  {
    void DisableTreeView();
    void EnableTreeView();
    void FocusTreeView();
    void PopulateTreeView(IEnumerable<Experiment> experiments);
  }
}
