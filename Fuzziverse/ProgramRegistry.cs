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
      this.For<DatabaseConnector>()
          .Singleton();

      this.For<ISimulateExperiments>()
          .Use<ExperimentSimulator>()
          .Singleton();

      this.ConfigureWinForms();
      this.ConfigureControllers();
    }

    private void ConfigureWinForms()
    {
      this.For<ProgramView>()
          .Singleton();

      this.For<IViewDatabases>()
          .Use(ctx => ctx.GetInstance<ProgramView>().DatabaseView);

      this.For<IViewExperiments>()
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
