CREATE PROCEDURE dbo.CreateOrganismState
  @OrganismId BIGINT,
  @ExperimentTurnId BIGINT,
  @X INT,
  @Y INT, 
  @Health DECIMAL(3, 2)
AS
BEGIN
  DECLARE @OrganismStateId BIGINT

  INSERT INTO dbo.OrganismState (OrganismId, ExperimentTurnId, X, Y, Health)
  VALUES (@OrganismId, @ExperimentTurnId, @X, @Y, @Health)

  SET @OrganismStateId = SCOPE_IDENTITY()
  SELECT @OrganismStateId AS OrganismStateId

  RETURN
END
