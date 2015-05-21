CREATE PROCEDURE dbo.CreateOrganismState
  @OrganismId BIGINT NOT NULL,
  @ExperimentTurnId BIGINT NOT NULL,
  @X INT NOT NULL,
  @Y INT NOT NULL, 
  @Health DECIMAL(3, 2) NOT NULL
AS
BEGIN
  DECLARE @OrganismStateId BIGINT NOT NULL

  INSERT INTO dbo.OrganismState (OrganismId, ExperimentTurnId, X, Y, Health)
  VALUES (@OrganismId, @ExperimentTurnId, @X, @Y, @Health)

  SET @OrganismStateId = SCOPE_IDENTITY()
  SELECT @OrganismStateId AS OrganismStateId

  RETURN
END
