﻿using System;
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
    void DisableExperimentTreeView();
    void EnableExperimentTreeView();
    void FocusExperimentTreeView();
    void PopulateExperimentTreeView(IEnumerable<Experiment> experiments);
    long? GetSelectedExperimentId();
    void AddExperimentSelectionChangingHandler(TreeViewCancelEventHandler handler);
    void AddExperimentSelectionChangedHandler(TreeViewEventHandler handler);

    void DisablePhaseTreeView();
    void EnablePhaseTreeView();
    void FocusPhaseTreeView();
    void PopulatePhaseTreeView(Dictionary<int, List<int>> daysToPhases);
    void AddPhaseSelectionChangingHandler(TreeViewCancelEventHandler handler);
    void AddPhaseSelectionChangedHandler(TreeViewEventHandler handler);

    void DisablePlayStopButtons();
    void EnablePlayStopButtons();
  }
}
