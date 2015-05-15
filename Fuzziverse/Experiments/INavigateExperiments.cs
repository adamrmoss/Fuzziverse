using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzziverse.Experiments
{
  public interface INavigateExperiments
  {
    void DisableTreeView();
    void EnableTreeView();
    void FocusTreeView();
  }
}
