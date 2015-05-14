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

    public ProgramController(MainForm mainForm)
    {
      this.mainForm = mainForm;
    }

    public void StartApplication() {
      Application.Run(this.mainForm);
    }

    internal static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var container = new Container(exp => exp.AddRegistry<ProgramRegistry>());
      var programController = container.GetInstance<ProgramController>();
      programController.StartApplication();
    }
  }
}
