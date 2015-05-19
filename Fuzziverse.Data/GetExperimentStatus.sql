CREATE FUNCTION dbo.GetExperimentStatus(@ExperimentId BIGINT)
  RETURNS @ReturnTable TABLE(LatestExperimentTurnId BIGINT, LatestSimulationTime BIGINT, LatestSunX INT, LatestSunY INT, LatestSunRadius INT) AS
BEGIN
  DECLARE @LatestExperimentTurnId BIGINT
  DECLARE @LatestSimulationTime BIGINT
  DECLARE @LatestSunX INT
  DECLARE @LatestSunY INT
  DECLARE @LatestSunRadius INT

  SELECT @LatestSimulationTime = MAX(et.SimulationTime)
  FROM ExperimentTurn AS et
  WHERE et.ExperimentId = @ExperimentId

  SELECT @LatestExperimentTurnId = et.Id,
         @LatestSunX = et.SunX,
         @LatestSunY = et.SunY,
         @LatestSunRadius = et.SunRadius
  FROM dbo.ExperimentTurn AS et
  WHERE et.SimulationTime = @LatestSimulationTime

  INSERT @ReturnTable
  VALUES(@LatestExperimentTurnId, @LatestSimulationTime, @LatestSunX, @LatestSunY, @LatestSunRadius)

  RETURN
END
