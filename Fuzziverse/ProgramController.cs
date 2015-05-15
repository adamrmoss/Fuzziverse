using System.Windows.Forms;
using Fuzziverse.Databases;
using Fuzziverse.Simulations;
using StructureMap;

namespace Fuzziverse
{
  public class ProgramController
  {
    private readonly MainForm mainForm;
    private readonly DatabaseController databaseController;
    private readonly SimulationController simulationController;

    public ProgramController(MainForm mainForm, DatabaseController databaseController, SimulationController simulationController)
    {
      this.mainForm = mainForm;
      this.databaseController = databaseController;
      this.simulationController = simulationController;
    }

    public void StartApplication()
    {
      Application.Run(this.mainForm);
    }

    public void Initialize()
    {
      this.databaseController.Initialize();
      this.simulationController.Initialize();
    }

    internal static void Main()
    {
      InitializeWinForms();

      var container = new Container(exp => exp.AddRegistry<ProgramRegistry>());
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
