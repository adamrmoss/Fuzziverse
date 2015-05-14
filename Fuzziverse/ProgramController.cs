using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StructureMap;

namespace Fuzziverse
{
  public class ProgramController
  {
    private readonly MainForm mainForm;
    private readonly ServerController serverController;
    private readonly SimulationController simulationController;

    public ProgramController(MainForm mainForm, ServerController serverController, SimulationController simulationController)
    {
      this.mainForm = mainForm;
      this.serverController = serverController;
      this.simulationController = simulationController;
    }

    public void StartApplication()
    {
      Application.Run(this.mainForm);
    }

    public void Initialize()
    {
      this.serverController.Initialize();
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
