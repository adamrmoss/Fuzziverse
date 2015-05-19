CREATE FUNCTION dbo.GetExperimentPhases(@ExperimentId BIGINT)
  RETURNS @ReturnTable TABLE([Day] INT NOT NULL, Phase INT NOT NULL) AS
BEGIN
  INSERT @ReturnTable
  SELECT et.[Day], et.Phase
  FROM dbo.ExperimentTurn AS et
  WHERE et.ExperimentId = @ExperimentId
  GROUP BY et.[Day], et.Phase
  RETURN
END
