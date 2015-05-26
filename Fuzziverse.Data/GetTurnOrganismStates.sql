CREATE PROCEDURE dbo.GetTurnOrganismStates
  @ExperimentTurnId BIGINT
AS
BEGIN
  SELECT os.Id, os.OrganismId,
         o.Red, o.Green, o.Blue,
         os.X, os.Y, os.Health
  FROM dbo.OrganismState AS os JOIN
       dbo.Organism AS o ON os.OrganismId = o.Id
  WHERE os.ExperimentTurnId = @ExperimentTurnId
  ORDER BY os.OrganismId
  RETURN
END
