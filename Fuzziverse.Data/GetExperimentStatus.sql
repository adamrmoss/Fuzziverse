CREATE FUNCTION dbo.GetExperimentStatus(@ExperimentId BIGINT)
  RETURNS @ReturnTable TABLE(LatestExperimentTurnId BIGINT, LatestSimulationTime INT, LatestRandomSeed INT, LatestSunX INT, LatestSunY INT, LatestSunRadius INT) AS
BEGIN
  DECLARE @LatestExperimentTurnId BIGINT
  DECLARE @LatestSimulationTime INT
  DECLARE @LatestRandomSeed INT
  DECLARE @LatestSunX INT
  DECLARE @LatestSunY INT
  DECLARE @LatestSunRadius INT

  SELECT @LatestSimulationTime = MAX(et.SimulationTime)
  FROM ExperimentTurn AS et
  WHERE et.ExperimentId = @ExperimentId

  SELECT @LatestExperimentTurnId = et.Id,
         @LatestRandomSeed = et.RandomSeed,
         @LatestSunX = et.SunX,
         @LatestSunY = et.SunY,
         @LatestSunRadius = et.SunRadius
  FROM dbo.ExperimentTurn AS et
  WHERE et.SimulationTime = @LatestSimulationTime

  INSERT @ReturnTable
  VALUES(@LatestExperimentTurnId, @LatestSimulationTime, @LatestRandomSeed, @LatestSunX, @LatestSunY, @LatestSunRadius)

  RETURN
END
