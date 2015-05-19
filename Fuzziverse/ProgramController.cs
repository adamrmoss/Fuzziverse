using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fuzziverse.Databases;
using Fuzziverse.Experiments;
using Fuzziverse.PhaseVisualization;
using Fuzziverse.Simulations;
using GuardClaws;
using StructureMap;

namespace Fuzziverse
{
  public class ProgramController
  {
    private readonly ProgramView programView;
    private readonly DatabaseConnector databaseConnector;
    private readonly DatabaseController databaseController;
    private readonly ExperimentController experimentController;
    private readonly PhaseVisualizationController phaseVisualizationController;
    private readonly IViewExperiments experimentView;
    private readonly ISimulateExperiments experimentSimulator;

    public ProgramController(ProgramView programView,
                             DatabaseConnector databaseConnector,
                             DatabaseController databaseController,
                             ExperimentController experimentController,
                             PhaseVisualizationController phaseVisualizationController,
                             IViewExperiments experimentView,
                             ISimulateExperiments experimentSimulator)
    {
      Claws.NotNull(() => programView);
      Claws.NotNull(() => databaseConnector);
      Claws.NotNull(() => databaseController);
      Claws.NotNull(() => experimentController);
      Claws.NotNull(() => phaseVisualizationController);
      Claws.NotNull(() => experimentView);
      Claws.NotNull(() => experimentSimulator);

      this.programView = programView;
      this.databaseConnector = databaseConnector;
      this.databaseController = databaseController;
      this.experimentController = experimentController;
      this.phaseVisualizationController = phaseVisualizationController;
      this.experimentView = experimentView;
      this.experimentSimulator = experimentSimulator;
    }

    public void StartApplication()
    {
      this.Initialize();
      Application.Run(this.programView);
    }

    public void Initialize()
    {
      this.databaseConnector.DatabasePinged += this.OnDatabasePing;
      this.experimentView.AddPlayRadioButtonClickedHandler(this.OnPlayRadioButtonClicked);
      this.experimentView.AddStopRadioButtonClickedHandler(this.OnStopRadioButtonClicked);

      this.databaseController.Initialize();
      this.experimentController.Initialize();
      this.phaseVisualizationController.Initialize();
    }

    private void OnDatabasePing()
    {
      this.experimentController.LoadExperiments();
    }

    private void OnPlayRadioButtonClicked(object sender, EventArgs eventArgs)
    {
      var experimentId = this.experimentView.GetSelectedExperimentId();
      if (experimentId == null)
        return;

      var taskToSimulateSingleTurn = this.experimentSimulator.GetTaskToSimulateSingleTurn(experimentId.Value);
      taskToSimulateSingleTurn.RunSynchronously();

      this.experimentView.EnablePlayStopButtons();
      this.experimentView.ClickStopRadioButton();
    }

    private void OnStopRadioButtonClicked(object sender, EventArgs eventArgs)
    {
    }

    [STAThread]
    internal static void Main()
    {
      InitializeWinForms();

      var container = new Container(cfg => cfg.AddRegistry<ProgramRegistry>());
      var programController = container.GetInstance<ProgramController>();

      programController.StartApplication();
    }

    private static void InitializeWinForms()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
    }
  }
}
