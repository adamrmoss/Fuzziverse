using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Fuzziverse.Core.Experiments;

namespace Fuzziverse.Experiments
{
  public interface IViewExperiments
  {
    void DisableExperimentTreeView();
    void EnableExperimentTreeView();
    void FocusExperimentTreeView();
    void PopulateExperimentTreeView(IEnumerable<Experiment> experiments);
    void AddExperimentSelectionChangedHandler(TreeViewEventHandler handler);

    void DisableNewExperimentButton();
    void EnableNewExperimentButton();
    void AddNewExperimentButtonClickedHandler(EventHandler handler);

    void DisablePhasesTreeView();
    void EnablePhasesTreeView();
    void FocusPhasesTreeView();
    void PopulatePhasesTreeView(Dictionary<int, List<ExperimentPhase>> daysToPhases);
    void AddPhaseSelectionChangedHandler(TreeViewEventHandler handler);

    void DisablePlayStopButtons();
    void EnablePlayStopButtons();
    void AddPlayRadioButtonClickedHandler(EventHandler handler);
    void AddStopRadioButtonClickedHandler(EventHandler handler);
    void ClickStopRadioButton();
  }
}
