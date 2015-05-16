CREATE FUNCTION dbo.GetExperimentDays(@ExperimentId BIGINT)
  RETURNS @ReturnTable TABLE([Day] INT) AS
BEGIN
  INSERT @ReturnTable
  SELECT et.[Day]
  FROM dbo.ExperimentTurn AS et
  WHERE et.ExperimentId = @ExperimentId
  GROUP BY et.[Day]
  RETURN
END
