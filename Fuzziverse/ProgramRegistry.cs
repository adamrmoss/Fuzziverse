using Fuzziverse.Databases;
using Fuzziverse.Simulations;
using StructureMap.Configuration.DSL;

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

      this.For<IEditDatabaseSettings>()
          .Use(ctx => ctx.GetInstance<MainForm>());
    }

    private void ConfigureControllers()
    {
      this.For<ProgramController>()
          .Singleton();

      this.For<DatabaseController>()
          .Singleton();

      this.For<SimulationController>()
          .Singleton();
    }
  }
}
