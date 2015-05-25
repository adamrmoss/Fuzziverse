CREATE PROCEDURE dbo.CreateExperimentTurn
  @ExperimentId BIGINT,
  @SimulationTime INT,
  @Day INT,
  @PhaseOfDay INT,
  @Phase INT,
  @RandomSeed INT,
  @SunX INT,
  @SunY INT,
  @ExtraEnergy DECIMAL(6, 2)
AS
BEGIN
  DECLARE @ExperimentTurnId BIGINT

  INSERT INTO dbo.ExperimentTurn (ExperimentId, SimulationTime, [Day], PhaseOfDay, Phase, RandomSeed, SunX, SunY, ExtraEnergy)
  VALUES (@ExperimentId, @SimulationTime, @Day, @PhaseOfDay, @Phase, @RandomSeed, @SunX, @SunY, @ExtraEnergy)

  SET @ExperimentTurnId = SCOPE_IDENTITY()
  SELECT @ExperimentTurnId AS ExperimentTurnId

  RETURN
END
