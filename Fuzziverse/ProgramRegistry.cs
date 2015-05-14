using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

      this.For<TabControl>()
          .Use(ctx => (TabControl) ctx.GetInstance<MainForm>().Controls["tabControl"])
          .Named("mainTabControl");

      this.For<TabPage>()
          .Use(ctx => ctx.GetInstance<TabControl>("mainTabControl").TabPages["serverTabPage"])
          .Named("serverTabPage");

      this.For<TabPage>()
          .Use(ctx => ctx.GetInstance<TabControl>("mainTabControl").TabPages["simulationTabPage"])
          .Named("simulationTabPage");
    }

    private void ConfigureControllers()
    {
      this.ForConcreteType<ProgramController>().Configure
          .Singleton();

      this.ForConcreteType<ServerController>().Configure
          .Singleton()
          .Ctor<TabPage>("serverTabPage").Is(x => x.GetInstance<TabPage>("serverTabPage"));

      this.ForConcreteType<SimulationController>().Configure
          .Singleton()
          .Ctor<TabPage>("simulationTabPage").Is(x => x.GetInstance<TabPage>("simulationTabPage"));
    }
  }
}
