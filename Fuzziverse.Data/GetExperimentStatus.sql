CREATE PROCEDURE dbo.GetExperimentStatus
  @ExperimentId BIGINT
AS
BEGIN
  DECLARE @LatestExperimentTurnId BIGINT
  DECLARE @LatestSimulationTime INT
  DECLARE @LatestRandomSeed INT
  DECLARE @LatestSunX INT
  DECLARE @LatestSunY INT
  DECLARE @LatestExtraEnergy DECIMAL(6, 2)

  SELECT @LatestSimulationTime = MAX(et.SimulationTime)
  FROM ExperimentTurn AS et
  WHERE et.ExperimentId = @ExperimentId

  SELECT @LatestExperimentTurnId = et.Id,
         @LatestRandomSeed = et.RandomSeed,
         @LatestSunX = et.SunX,
         @LatestSunY = et.SunY,
         @LatestExtraEnergy = et.ExtraEnergy
  FROM dbo.ExperimentTurn AS et
  WHERE et.SimulationTime = @LatestSimulationTime

  SELECT @LatestExperimentTurnId AS LatestExperimentTurnId, @LatestSimulationTime AS LatestSimulationTime,
         @LatestRandomSeed AS LatestRandomSeed, @LatestSunX AS LatestSunX, @LatestSunY AS LatestSunY,
         @LatestExtraEnergy AS LatestExtraEnergy
  RETURN
END
