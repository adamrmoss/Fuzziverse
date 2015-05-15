using System.Windows.Forms;
using Fuzziverse.Databases;
using Fuzziverse.Experiments;
using Fuzziverse.Simulations;
using StructureMap;

namespace Fuzziverse
{
  public class ProgramController
  {
    private readonly ProgramView programView;
    private readonly DatabaseController databaseController;
    private readonly ExperimentController experimentController;
    private readonly SimulationController simulationController;

    public ProgramController(ProgramView programView,
                             DatabaseController databaseController,
                             ExperimentController experimentController,
                             SimulationController simulationController)
    {
      this.programView = programView;
      this.databaseController = databaseController;
      this.experimentController = experimentController;
      this.simulationController = simulationController;
    }

    public void StartApplication()
    {
      Application.Run(this.programView);
    }

    public void Initialize()
    {
      this.databaseController.Initialize();
      this.simulationController.Initialize();
    }

    internal static void Main()
    {
      InitializeWinForms();

      var container = new Container(cfg => cfg.AddRegistry<ProgramRegistry>());
      var programController = container.GetInstance<ProgramController>();

      programController.Initialize();
      programController.StartApplication();
    }

    private static void InitializeWinForms()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
    }
  }
}
