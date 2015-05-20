CREATE PROCEDURE dbo.CreateExperimentTurn
  @ExperimentId BIGINT,
  @SimulationTime INT,
  @Day INT,
  @Phase INT,
  @RandomSeed INT,
  @SunX INT,
  @SunY INT
AS
BEGIN
  DECLARE @ExperimentTurnId BIGINT

  INSERT INTO dbo.ExperimentTurn (ExperimentId, SimulationTime, [Day], Phase, RandomSeed, SunX, SunY)
  VALUES (@ExperimentId, @SimulationTime, @Day, @Phase, @RandomSeed, @SunX, @SunY)

  SET @ExperimentTurnId = SCOPE_IDENTITY()
  SELECT @ExperimentTurnId AS ExperimentTurnId

  RETURN
END
