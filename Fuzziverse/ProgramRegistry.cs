using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fuzziverse.Server;
using Fuzziverse.Simulation;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;

namespace Fuzziverse
{
  public class ProgramRegistry : Registry
  {
    public ProgramRegistry()
    {
      this.ConfigureWinForms();
      this.ConfigureControllers();
    }

    private void ConfigureWinForms()
    {
      this.For<MainForm>()
          .Singleton();

      this.For<IEditServerSettings>()
          .Use(ctx => ctx.GetInstance<MainForm>());
    }

    private void ConfigureControllers()
    {
      this.For<ProgramController>()
          .Singleton();

      this.For<ServerController>()
          .Singleton();

      this.For<SimulationController>()
          .Singleton();
    }
  }
}
