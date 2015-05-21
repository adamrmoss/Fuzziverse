CREATE PROCEDURE dbo.CreateExperimentTurn
  @ExperimentId BIGINT NOT NULL,
  @SimulationTime INT NOT NULL,
  @Day INT NOT NULL,
  @PhaseOfDay INT NOT NULL,
  @Phase INT NOT NULL,
  @RandomSeed INT NOT NULL,
  @SunX INT NOT NULL,
  @SunY INT NOT NULL,
  @ExtraEnergy DECIMAL(6, 2) NOT NULL
AS
BEGIN
  DECLARE @ExperimentTurnId BIGINT

  INSERT INTO dbo.ExperimentTurn (ExperimentId, SimulationTime, [Day], PhaseOfDay, Phase, RandomSeed, SunX, SunY, ExtraEnergy)
  VALUES (@ExperimentId, @SimulationTime, @Day, @PhaseOfDay, @Phase, @RandomSeed, @SunX, @SunY, @ExtraEnergy)

  SET @ExperimentTurnId = SCOPE_IDENTITY()
  SELECT @ExperimentTurnId AS ExperimentTurnId

  RETURN
END
