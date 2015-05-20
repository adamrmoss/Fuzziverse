CREATE PROCEDURE dbo.CreateExperimentTurn
  @ExperimentId BIGINT,
  @SimulationTime INT,
  @Day INT,
  @PhaseOfDay INT,
  @Phase INT,
  @RandomSeed INT,
  @SunX INT,
  @SunY INT
AS
BEGIN
  DECLARE @ExperimentTurnId BIGINT

  INSERT INTO dbo.ExperimentTurn (ExperimentId, SimulationTime, [Day], PhaseOfDay, Phase, RandomSeed, SunX, SunY)
  VALUES (@ExperimentId, @SimulationTime, @Day, @PhaseOfDay, @Phase, @RandomSeed, @SunX, @SunY)

  SET @ExperimentTurnId = SCOPE_IDENTITY()
  SELECT @ExperimentTurnId AS ExperimentTurnId

  RETURN
END
