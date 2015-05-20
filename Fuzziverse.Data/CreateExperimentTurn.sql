CREATE PROCEDURE dbo.CreateExperimentTurn
  @ExperimentId BIGINT,
  @SimulationTime INT,
  @Day INT,
  @Phase INT,
  @RandomSeed INT,
  @SunX INT,
  @SunY INT,
  @SunRadius INT
AS
BEGIN
  DECLARE @ExperimentTurnId BIGINT

  INSERT INTO dbo.ExperimentTurn (ExperimentId, SimulationTime, [Day], Phase, RandomSeed, SunX, SunY, SunRadius)
  VALUES (@ExperimentId, @SimulationTime, @Day, @Phase, @RandomSeed, @SunX, @SunY, @SunRadius)

  SET @ExperimentTurnId = SCOPE_IDENTITY()
  SELECT @ExperimentTurnId AS ExperimentTurnId

  RETURN
END
