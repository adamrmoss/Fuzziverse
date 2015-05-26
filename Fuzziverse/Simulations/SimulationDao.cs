using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuzziverse.Core.AlienSpaceTime;
using Fuzziverse.Core.Organisms;
using Fuzziverse.Databases;

namespace Fuzziverse.Simulations
{
  public static class SimulationDao
  {
    private const string createOrganismCommand = "EXEC dbo.CreateOrganism @Red, @Green, @Blue";
    private const string getTurnOrganismStatesQuery = "EXEC dbo.GetTurnOrganismStates @ExperimentTurnId";
    private const string createOrganismStateCommand = "EXEC dbo.CreateOrganismState @OrganismId, @ExperimentTurnId, @X, @Y, @Health";

    public static void SaveOrganism(this SqlConnection sqlConnection, Organism organism)
    {
      var sqlCommand = new SqlCommand(createOrganismCommand, sqlConnection);
      var redParameter = sqlCommand.Parameters.Add("@Red", SqlDbType.Decimal);
      redParameter.SqlValue = organism.Red;
      var greenParameter = sqlCommand.Parameters.Add("@Green", SqlDbType.Decimal);
      greenParameter.SqlValue = organism.Green;
      var blueParameter = sqlCommand.Parameters.Add("@Blue", SqlDbType.Decimal);
      blueParameter.SqlValue = organism.Blue;

      organism.Id = sqlCommand.ReadResults(reader => reader.GetInt64(0)).Single();
    }

    public static IList<OrganismState> GetTurnOrganismStates(this SqlConnection sqlConnection, long experimentTurnId)
    {
      var sqlCommand = new SqlCommand(getTurnOrganismStatesQuery, sqlConnection);
      var experimentTurnIdParameter = sqlCommand.Parameters.Add("@ExperimentTurnId", SqlDbType.BigInt);
      experimentTurnIdParameter.SqlValue = experimentTurnId;

      return sqlCommand.ReadResults(reader => new OrganismState {
        Id = reader.GetInt64(0),
        OrganismId = reader.GetInt64(1),
        ExperimentTurnId = experimentTurnId,
        Red = reader.GetDecimal(2),
        Green = reader.GetDecimal(3),
        Blue = reader.GetDecimal(4),
        Position = new AlienSpaceVector(reader.GetInt32(5),  reader.GetInt32(6)),
        Health = reader.GetDecimal(7),
      }).ToArray();
    }

    public static void SaveOrganismState(this SqlConnection sqlConnection, OrganismState organismState)
    {
      var sqlCommand = new SqlCommand(createOrganismStateCommand, sqlConnection);
      var organismIdParameter = sqlCommand.Parameters.Add("@OrganismId", SqlDbType.BigInt);
      organismIdParameter.SqlValue = organismState.OrganismId;
      var experimentTurnIdParameter = sqlCommand.Parameters.Add("@ExperimentTurnId", SqlDbType.BigInt);
      experimentTurnIdParameter.SqlValue = organismState.ExperimentTurnId;
      var xParameter = sqlCommand.Parameters.Add("@X", SqlDbType.Int);
      xParameter.SqlValue = organismState.Position.X;
      var yParameter = sqlCommand.Parameters.Add("@Y", SqlDbType.Int);
      yParameter.SqlValue = organismState.Position.Y;
      var healthParameter = sqlCommand.Parameters.Add("@Health", SqlDbType.Decimal);
      healthParameter.SqlValue = organismState.Health;

      organismState.Id = sqlCommand.ReadResults(reader => reader.GetInt64(0)).Single();
    }
  }
}
