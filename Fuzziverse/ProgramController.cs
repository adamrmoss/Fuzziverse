using System;
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

    public ProgramController(ProgramView programView,
                             DatabaseConnector databaseConnector,
                             DatabaseController databaseController,
                             ExperimentController experimentController,
                             PhaseVisualizationController phaseVisualizationController)
    {
      Claws.NotNull(() => programView);
      Claws.NotNull(() => databaseConnector);
      Claws.NotNull(() => databaseController);
      Claws.NotNull(() => experimentController);
      Claws.NotNull(() => phaseVisualizationController);

      this.programView = programView;
      this.databaseConnector = databaseConnector;
      this.databaseController = databaseController;
      this.experimentController = experimentController;
      this.phaseVisualizationController = phaseVisualizationController;
    }

    public void StartApplication()
    {
      this.Initialize();
      Application.Run(this.programView);
    }

    public void Initialize()
    {
      this.databaseConnector.DatabasePinged += this.OnDatabasePing;
      this.databaseController.Initialize();
      this.experimentController.Initialize();
      this.phaseVisualizationController.Initialize();
    }

    private void OnDatabasePing()
    {
      this.experimentController.LoadExperiments();
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
