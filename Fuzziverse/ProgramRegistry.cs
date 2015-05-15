using Fuzziverse.Databases;
using Fuzziverse.Experiments;
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
      this.For<ProgramView>()
          .Singleton();

      this.For<IEditDatabaseSettings>()
          .Use(ctx => ctx.GetInstance<ProgramView>().DatabaseView);

      this.For<INavigateExperiments>()
          .Use(ctx => ctx.GetInstance<ProgramView>().ExperimentView);
        
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
