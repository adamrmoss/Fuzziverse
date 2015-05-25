CREATE PROCEDURE dbo.GetTurnOrganismStates
  @ExperimentTurnId BIGINT NOT NULL
AS
BEGIN
  SELECT os.Id, os.OrganismId, os.X, os.Y, os.Health
  FROM dbo.OrganismState AS os
  WHERE os.ExperimentTurnId = @ExperimentTurnId
  ORDER BY os.OrganismId
  RETURN
END
