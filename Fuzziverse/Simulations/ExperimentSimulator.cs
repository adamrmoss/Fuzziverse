using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Fuzziverse.Core.AlienSpaceTime;
using Fuzziverse.Core.Experiments;
using Fuzziverse.Core.Organisms;
using Fuzziverse.Core.Statistical;
using Fuzziverse.Databases;
using Fuzziverse.Experiments;
using GuardClaws;

namespace Fuzziverse.Simulations
{
  public class ExperimentSimulator : ISimulateExperiments
  {
    private static readonly IEnumerable<AlienSpaceVector> allPoints;

    static ExperimentSimulator()
    {
      allPoints = from x in Enumerable.Range(0, AlienSpaceVector.WorldWidth)
                  from y in Enumerable.Range(0, AlienSpaceVector.WorldHeight)
                  select new AlienSpaceVector(x, y);
    }

    private readonly DatabaseConnector databaseConnector;

    public ExperimentSimulator(DatabaseConnector databaseConnector)
    {
      Claws.NotNull(() => databaseConnector);

      this.databaseConnector = databaseConnector;
    }

    public void SimulateSingleTurn(long experimentId)
    {
      if (!this.databaseConnector.DatabaseHasBeenPinged)
        throw new InvalidOperationException("Cannot run simulation without having pinged the database.");

      //try {
      using (var sqlConnection = this.databaseConnector.OpenSqlConnection()) {
        var experimentStatus = sqlConnection.GetExperimentStatus(experimentId);

        var existingOrganismStates = experimentStatus.LatestExperimentTurnId == null ? new OrganismState[0] : sqlConnection.GetTurnOrganismStates(experimentStatus.LatestExperimentTurnId.Value);

        var newExperimentTurn = BuildNextExperimentTurn(experimentStatus);
        var random = new Random(newExperimentTurn.RandomSeed);

        var newOrganismStates = existingOrganismStates
          .ToDictionary(organismState => organismState.OrganismId,
                        existingOrganismState => new OrganismState {
                          OrganismId = existingOrganismState.OrganismId,
                          Position = existingOrganismState.Position,
                          Health = existingOrganismState.Health,
                        });

        foreach (var existingOrganismState in newOrganismStates.Values.OrderBy(state => state.OrganismId).ToArray()) {
          // TODO: Think first
          ReleaseEnergy(newExperimentTurn, existingOrganismState, Experiment.HungerRate);
          var isInSun = AlienSpaceVector.GetCoordinateDelta(existingOrganismState.Position, newExperimentTurn.SunPosition).Abs() < Experiment.SunRadius;
          if (isInSun)
            AbsorbEnergy(newExperimentTurn, existingOrganismState, Experiment.SunEnergyGift);
          if (existingOrganismState.Health <= 0)
            newOrganismStates.Remove(existingOrganismState.OrganismId);
        }

        var numberOfOrganismsToCreate = Math.Min((int) newExperimentTurn.ExtraEnergy, Experiment.MaxBirthRate);
        newExperimentTurn.ExtraEnergy -= numberOfOrganismsToCreate;

        var newPositions = allPoints
          .Except(newOrganismStates.Values.Select(state => state.Position))
          .Randomize(random)
          .Take(numberOfOrganismsToCreate);

        foreach (var newPosition in newPositions) {
          var newOrganism = new Organism {
            Red = 0,
            Green = 1,
            Blue = 0,
          };

          sqlConnection.SaveOrganism(newOrganism);

          newOrganismStates[newOrganism.Id] = new OrganismState {
            OrganismId = newOrganism.Id,
            Position = newPosition,
            Health = 1,
          };
        }

        sqlConnection.SaveExperimentTurn(newExperimentTurn);
        foreach (var organismState in newOrganismStates.Values) {
          organismState.ExperimentTurnId = newExperimentTurn.Id;
          sqlConnection.SaveOrganismState(organismState);
        }
      }
      //} catch (Exception e) {
      //}
    }

    private static ExperimentTurn BuildNextExperimentTurn(ExperimentStatus experimentStatus)
    {
      var newSimulationTime = experimentStatus.LatestSimulationTime + 1.Turn() ?? new AlienDateTime(0);

      var random = experimentStatus.LatestRandomSeed == null ? new Random() : new Random(experimentStatus.LatestRandomSeed.Value);
      var moveUp = random.Next(4) == 0;

      var newSunPosition = (experimentStatus.LatestSunPosition == null ?
                            new AlienSpaceVector(32, 18) :
                            experimentStatus.LatestSunPosition.Value + new AlienSpaceVector(1, moveUp ? -1 : 0)).ToCoordinates();

      var newExtraEnergy = experimentStatus.LatestExtraEnergy ?? AlienSpaceVector.WorldWidth * AlienSpaceVector.WorldHeight * Experiment.Richness;

      var newExperimentTurn = new ExperimentTurn {
        ExperimentId = experimentStatus.ExperimentId,
        SimulationTime = newSimulationTime,
        RandomSeed = random.Next(),
        SunPosition = newSunPosition,
        ExtraEnergy = newExtraEnergy,
      };
      return newExperimentTurn;
    }

    private static void AbsorbEnergy(ExperimentTurn experimentTurn, OrganismState organismState, decimal delta)
    {
      Claws.AtLeast(() => delta, 0);

      delta = Math.Min(delta, Math.Min(experimentTurn.ExtraEnergy, 1 - organismState.Health));

      experimentTurn.ExtraEnergy -= delta;
      organismState.Health += delta;
    }

    private static void ReleaseEnergy(ExperimentTurn experimentTurn, OrganismState organismState, decimal delta)
    {
      Claws.AtLeast(() => delta, 0);

      delta = Math.Min(delta, organismState.Health);

      organismState.Health -= delta;
      experimentTurn.ExtraEnergy += delta;
    }
  }
}
