CREATE PROCEDURE dbo.GetExperimentPhaseTurns
  @ExperimentId BIGINT,
  @Phase INT
AS
BEGIN
  SELECT et.Id AS ExperimentTurnId, et.SimulationTime, et.RandomSeed, et.SunX, et.SunY
  FROM dbo.ExperimentTurn AS et
  WHERE et.ExperimentId = @ExperimentId AND
        et.Phase = @Phase
  RETURN
END
